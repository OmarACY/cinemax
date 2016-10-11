/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.*;

/**
 *
 * @author MILAN
 * @param <Modelo>
 * @param <Vista>
 */
public abstract class Conexion<Modelo, Vista> {
    protected Connection db;
    protected Vista vista;
    
    public Conexion(Vista vista){
        db = null;
        this.vista = vista;
    }
    
    protected void realizaConexion() throws ClassNotFoundException, SQLException {
        String nombreDriver  ="org.postgresql.Driver";
        int puerto = 5432;
        String baseDatos = "Cinemax";
        String url = String.format("jdbc:postgresql://localhost:%d/%s", puerto, baseDatos);
        // Usuario y Contraseña MILAN-PC 
        //String nombreUsuario = "root";
        //String contraseña = "toor";
        // Usuario y Contraseña OMARACY-MAC 
        String nombreUsuario = "postgres";
        String contraseña = "postgres";
        
        Class.forName(nombreDriver);
        db = DriverManager.getConnection(url, nombreUsuario, contraseña);
    }
    
    protected void cierraConexion() throws SQLException{
        db.close();
        db = null;
    }
    
    public abstract boolean inserta(Modelo modelo) throws ClassNotFoundException, SQLException;
    public abstract boolean elimina(Modelo modelo);
    public abstract boolean actualiza(Modelo modelo);
}
