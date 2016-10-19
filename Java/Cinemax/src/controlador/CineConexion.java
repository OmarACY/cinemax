/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.table.DefaultTableModel;
import modelo.Cine;
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
}
