/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import javax.swing.JComboBox;
import javax.swing.table.DefaultTableModel;
import modelo.Cine;
import modelo.Sala;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class CineConexion extends Conexion<Cine> {

    @Override
    public boolean inserta(Cine modelo) {
        String sentencia1;
        String sentencia2;
        int filasAfectadas;
        
        sentencia1 = String.format("INSERT INTO Cine.cine (nombre, num_salas, colonia, calle, numero"+
                ") VALUES ('%s',%d,'%s','%s',%d)",modelo.getNombre(),modelo.getNum_salas(),modelo.getColonia(),modelo.getCalle(),
                modelo.getNumero());       
        try {
            filasAfectadas = ejecutaSentencia(sentencia1);
            
            if(filasAfectadas > 0){
               sentencia2 = String.format("INSERT INTO Cine.tel_cin (clave_cin, telefono"+
                ") VALUES ('%s','%s')",ObtenUltimoID("Cine.cine", "clave_cin"),modelo.getTelefono());
               ejecutaSentencia(sentencia2);
            }
            
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        
        return (filasAfectadas > 0);
    }
       
    @Override
    public boolean elimina(Cine modelo) {
        String sentencia1;
        String sentencia2;
        int filasAfectadas;
        
        sentencia1 = String.format("DELETE FROM Cine.sala WHERE clave_cin = %d",modelo.getClave_cin());
        sentencia2 = String.format("DELETE FROM Cine.tel_cin WHERE clave_cin = %d",modelo.getClave_cin()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia1);
            filasAfectadas = ejecutaSentencia(sentencia2);
            
            if(filasAfectadas > 0){
                sentencia1 = String.format("DELETE FROM Cine.cine WHERE clave_cin = %d",modelo.getClave_cin());
                filasAfectadas = ejecutaSentencia(sentencia1);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean actualiza(Cine modelo) {
        String sentencia1;
        String sentencia2;
        int filasAfectadas;
        
        sentencia1 = String.format("UPDATE Cine.cine SET nombre = '%s', colonia = '%s', calle = '%s' ,numero = %d WHERE clave_cin = %d", 
                modelo.getNombre(), modelo.getColonia(), modelo.getCalle(), modelo.getNumero(),modelo.getClave_cin());
        
        sentencia2 = String.format("UPDATE Cine.tel_cin SET telefono = '%s' WHERE clave_cin = %d", 
                modelo.getTelefono(),modelo.getClave_cin());
        
        try {
            filasAfectadas = ejecutaSentencia(sentencia1);
            
            if(filasAfectadas > 0)
                ejecutaSentencia(sentencia2);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }
    
    public DefaultTableModel getDatosTabla() {
        String consulta;
        
        consulta = "SELECT cine.*, tel.telefono FROM Cine.cine as cine LEFT JOIN Cine.tel_cin as tel ON tel.clave_cin = cine.clave_cin";
        
        try {
            return getModeloTabla(ejecutaConsulta(consulta));
        }
        catch(ClassNotFoundException | SQLException ex) {
            return null;
        }
    }
    
    public String ObtenIDCine(String claveSala)
    {
        String consulta;        
        consulta = "SELECT clave_cin from Cine.sala where clave_sal=" + claveSala + " limit 1";
        String id;
        
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            rs.next();
            id = rs.getString("clave_cin");
            return id;
        }
        catch(ClassNotFoundException | SQLException ex) {
            return "-1";
        }
    }    
    
    public int obtenerCupoSala(String claveSala){
        String consulta;        
        consulta = "SELECT cupo from Cine.sala where clave_sal=" + claveSala;
        int cupo = 0;        
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            rs.next();
            cupo = Integer.parseInt(rs.getString("cupo"));
            return cupo;
        }
        catch(ClassNotFoundException | SQLException ex) {
            return 0;
        }
    }
    
    public ArrayList<Sala> obtenerSalas(String claveCine){
        ArrayList<Sala> listaSala = new ArrayList<Sala>();
        String consulta;
        Sala sala;
        consulta = "SELECT clave_sal, cupo FROM Cine.sala WHERE clave_cin =" + claveCine ;
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            while(rs.next()) {
                sala = new Sala();
                sala.setClaveSala(Integer.parseInt(rs.getString("clave_sal")));
                sala.setCupo(Integer.parseInt(rs.getString("cupo")));
                listaSala.add(sala);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
        
        return listaSala;
    }
    
    public boolean actualizaSalas(ArrayList<Sala> listaSala) {
        String sentencia;
        int filasAfectadas = 0;
        
        for(Sala sala : listaSala){
            sentencia = String.format("UPDATE Cine.sala SET cupo = %d WHERE clave_sal = %d", 
                    sala.getCupo(),sala.getClaveSala());

            try {
                filasAfectadas = ejecutaSentencia(sentencia);

            }
            catch(ClassNotFoundException | SQLException ex) {
                //Mostrar Excepcion
            }
        }
        
        return (filasAfectadas > 0);
    }
    
    @Override
    public void rellenaComboBox(JComboBox cb, String args[]) {
        String consulta;
        
        consulta = "SELECT clave_cin, nombre FROM Cine.cine";
        try {
            cb.removeAllItems();
            ResultSet rs = ejecutaConsulta(consulta);
            while(rs.next()) {
                String nombreComppleto = rs.getString("clave_cin") + "-" + rs.getString("nombre");
                cb.addItem(nombreComppleto);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
    }    
}
