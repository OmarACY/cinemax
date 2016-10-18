/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.*;
import java.util.Vector;
import javax.swing.JComboBox;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author MILAN
 * @param <Modelo>
 */
public abstract class Conexion<Modelo> {
    protected Connection db;
    
    public Conexion(){
        db = null;
    }
    
    protected void realizaConexion() throws ClassNotFoundException, SQLException {
        String nombreDriver  ="org.postgresql.Driver";
        int puerto = 5432;
        String baseDatos = "cinemax";
        String url = String.format("jdbc:postgresql://localhost:%d/%s", puerto, baseDatos);
        String nombreUsuario = "postgres";
        String contraseña = "postgres";
        
        Class.forName(nombreDriver);
        db = DriverManager.getConnection(url, nombreUsuario, contraseña);
    }
    
    protected void cierraConexion() throws SQLException{
        db.close();
        db = null;
    }
    
    protected int ejecutaSentencia(String sentencia) throws ClassNotFoundException, SQLException {
        Statement stmt;
        int filasAfectadas;
        
        realizaConexion();
        stmt = db.createStatement();
        filasAfectadas = stmt.executeUpdate(sentencia);
        cierraConexion();
        return filasAfectadas;
    }
    
    protected ResultSet ejecutaConsulta(String consulta) throws ClassNotFoundException, SQLException {
        Statement stmt;
        ResultSet rs;
        
        realizaConexion();
        stmt = db.createStatement();
        rs = stmt.executeQuery(consulta);
        cierraConexion();
        return rs;
    }
    
    protected DefaultTableModel getModeloTabla(ResultSet rs) throws SQLException {
        ResultSetMetaData metadata = rs.getMetaData();
        int cantidadColumnas = metadata.getColumnCount();
        Vector<String> nombresColumnas = new Vector<String>();
        Vector<Vector<Object>> tuplas = new Vector<Vector<Object>>();
        
        // Nombres Columnas
        for(int columna = 1; columna <= cantidadColumnas; columna++) {
            nombresColumnas.add(metadata.getColumnName(columna));
        }
        
        // Recuperacion de tuplas
        while(rs.next()) {
            Vector<Object> renglon = new Vector<Object>();
            for(int columna = 1; columna <= cantidadColumnas; columna++) {
                renglon.add(rs.getObject(columna));
            }
            tuplas.add(renglon);
        }
        return new DefaultTableModel(tuplas, nombresColumnas);
   }
    
    public abstract boolean inserta(Modelo modelo);
    public abstract boolean elimina(Modelo modelo);
    public abstract boolean actualiza(Modelo modelo);
}
