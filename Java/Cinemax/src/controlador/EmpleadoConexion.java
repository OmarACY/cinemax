/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.table.DefaultTableModel;
import modelo.Empleado;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class EmpleadoConexion extends Conexion<Empleado>{

    @Override
    public boolean inserta(Empleado modelo) {     
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("INSERT INTO Persona.empleado (nombres, app, apm,fecha_nac,colonia,calle,numero,contraseña"+
                ") VALUES ('%s','%s','%s','%s','%s','%s',%d,'%s')",modelo.getNombres(),modelo.getApp(),modelo.getApm(),
                modelo.getFecha_nac().toString(),modelo.getColonia(),modelo.getCalle(),modelo.getNumero(),modelo.getContraseña()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean elimina(Empleado modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("DELETE FROM Persona.empleado WHERE clave_emp = %d",modelo.getClave_emp()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean actualiza(Empleado modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("UPDATE Persona.empleado SET nombres = '%s', app = '%s', apm = '%s', fecha_nac = '%s', colonia = '%s', calle = '%s' ,numero = %d ,contraseña = '%s' WHERE clave_emp = %d", 
                modelo.getNombres(), modelo.getApp(), modelo.getApm(), modelo.getFecha_nac().toString(), modelo.getColonia(), modelo.getCalle(), modelo.getNumero(), modelo.getContraseña(), modelo.getClave_emp()); 
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
        
        consulta = "SELECT * FROM Persona.empleado";
        
        try {
            return getModeloTabla(ejecutaConsulta(consulta));
        }
        catch(ClassNotFoundException | SQLException ex) {
            return null;
        }
    }
}
