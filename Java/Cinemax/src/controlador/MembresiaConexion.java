/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.SQLException;
import javax.swing.table.DefaultTableModel;
import modelo.Membresia;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class MembresiaConexion extends Conexion<Membresia> {

    @Override
    public boolean inserta(Membresia modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("INSERT INTO Persona.membresia (nombre, app, apm,fecha_nac,colonia,calle,numero,tipo,puntos"+
                ") VALUES ('%s','%s','%s','%s','%s','%s',%d,'%s',%d)",modelo.getNombre(),modelo.getApp(),modelo.getApm(),
                modelo.getFecha_nac().toString(),modelo.getColonia(),modelo.getCalle(),modelo.getNumero(),modelo.getTipo(),
                modelo.getPuntos()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean elimina(Membresia modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("DELETE FROM Persona.membresia WHERE clave_mem = %d",modelo.getClave_mem()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean actualiza(Membresia modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("UPDATE Persona.membresia SET nombre = '%s', app = '%s', apm = '%s', fecha_nac = '%s', colonia = '%s', calle = '%s' ,numero = %d ,tipo = '%s',puntos = %d WHERE clave_mem = %d", 
                modelo.getNombre(), modelo.getApp(), modelo.getApm(), modelo.getFecha_nac().toString(), modelo.getColonia(), modelo.getCalle(), modelo.getNumero(), modelo.getTipo(),modelo.getPuntos(), modelo.getClave_mem()); 
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
        
        consulta = "SELECT * FROM Persona.membresia";
        
        try {
            return getModeloTabla(ejecutaConsulta(consulta));
        }
        catch(ClassNotFoundException | SQLException ex) {
            return null;
        }
    }
    
}
