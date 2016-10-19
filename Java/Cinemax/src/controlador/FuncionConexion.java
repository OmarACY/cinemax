/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JComboBox;
import javax.swing.table.DefaultTableModel;
import modelo.Funcion;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class FuncionConexion extends Conexion<Funcion> {

    @Override
    public boolean inserta(Funcion modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("INSERT INTO Cine.funcion (clave_pel, clave_sal, hora_ini,hora_fin,fecha"+
                ") VALUES (%d,%d,'%s','%s','%s')",modelo.getClave_pel(),modelo.getClave_sal(),modelo.getHora_ini().toString(),
                modelo.getHora_fin().toString(),modelo.getFecha().toString()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean elimina(Funcion modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("DELETE FROM Cine.funcion WHERE clave_fun = %d",modelo.getClave_fun()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean actualiza(Funcion modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("UPDATE Cine.funcion SET clave_pel = %d, clave_sal = %d, hora_ini = '%s', hora_fin = '%s', fecha = '%s' WHERE clave_fun = %d", 
                modelo.getClave_pel(), modelo.getClave_sal(), modelo.getHora_ini().toString(), modelo.getHora_fin().toString(), modelo.getFecha().toString(),modelo.getClave_fun()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }
    
    public DefaultTableModel getDatosTabla() {
        String consulta;
        
        consulta = "SELECT * FROM Cine.funcion";
        
        try {
            return getModeloTabla(ejecutaConsulta(consulta));
        }
        catch(ClassNotFoundException | SQLException ex) {
            return null;
        }
    }
    
   public void rellenaComboBox(JComboBox cb,String tabla, String clave,String campo){
        String consulta;
        
        consulta = "SELECT * FROM " + tabla;
        try {
            cb.removeAllItems();
            ResultSet rs = ejecutaConsulta(consulta);
            while(rs.next()) {
                String nombre =rs.getString(clave) + "-" +  rs.getString(campo);
                cb.addItem(nombre);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
   }
   
   public void rellenaComboBoxSalas(JComboBox cb,String claveCin){
        String consulta;
        
        //consulta = "SELECT * FROM Cine.sala as sal INNER JOIN Cine.cine as cin ON sal.clave_cin=cin.clave_cin WHERE cin.nombre='"+nombreCin+"'";
        consulta = "SELECT * FROM Cine.sala WHERE clave_cin="+claveCin;
        try {
            cb.removeAllItems();
            ResultSet rs = ejecutaConsulta(consulta);
            while(rs.next()) {
                String clave = rs.getString("clave_sal");
                cb.addItem(clave);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
   }
   
   public boolean disponibilidadFuncion(Funcion modelo){
        String consulta;
        boolean disp = true;
        
        consulta = String.format( "SELECT * FROM Cine.Funcion where clave_sal =%d and "
                + "hora_fin >= '%s' and fecha = '%s' ",modelo.getClave_sal(),
                modelo.getHora_ini().toString(),modelo.getFecha().toString());
        
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            
            if(rs.next()){
                disp = false;
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
        return disp;
   }
}
