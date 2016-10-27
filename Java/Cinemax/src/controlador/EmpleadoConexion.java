/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javax.swing.JComboBox;
import javax.swing.JOptionPane;
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
        
        sentencia = String.format("INSERT INTO Persona.empleado (nombres, app, apm,fecha_nac,colonia,calle,numero,contraseña, nombre_rol"+
                ") VALUES ('%s','%s','%s','%s','%s','%s',%d,'%s', '%s')",modelo.getNombres(),modelo.getApp(),modelo.getApm(),
                modelo.getFecha_nac().toString(),modelo.getColonia(),modelo.getCalle(),modelo.getNumero(),modelo.getContraseña(), modelo.getNombre_rol()); 
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
        
        sentencia = String.format("UPDATE Persona.empleado SET nombres = '%s', app = '%s', apm = '%s', fecha_nac = '%s', colonia = '%s', calle = '%s' ,numero = %d ,contraseña = '%s', nombre_rol = '%s' WHERE clave_emp = %d", 
                modelo.getNombres(), modelo.getApp(), modelo.getApm(), modelo.getFecha_nac().toString(), modelo.getColonia(), modelo.getCalle(), modelo.getNumero(), modelo.getContraseña(), modelo.getNombre_rol(), modelo.getClave_emp()); 
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
    
    public long existe(Empleado modelo) {
        int existe = -1;       
        String consulta;
        
        consulta = "SELECT * FROM Persona.empleado where Concat(nombres, ' ', app, ' ', apm) = '" + modelo.getNombres()+ "' AND contraseña = '" + modelo.getContraseña() + "'";
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            if(rs.next()) {
                existe = Integer.parseInt(rs.getString("clave_emp"));
            }
            else {
                JOptionPane.showMessageDialog(null, "Contraseña incorrecta. Intente nuevamente", "Inicio de sesión", JOptionPane.ERROR_MESSAGE);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
        
        return existe;
    }
    
    public String obtenRol(String clave_emp) {
        String rol;       
        String consulta;
        
        rol = new String();
        consulta = "SELECT nombre_rol FROM Persona.empleado where clave_emp = '" + clave_emp + "'";
        try {
            ResultSet rs = ejecutaConsulta(consulta);
            if(rs.next()) {
                rol = rs.getString("nombre_rol");
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
        
        return rol;
    }

    @Override
    public void rellenaComboBox(JComboBox cb, String args[]) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
