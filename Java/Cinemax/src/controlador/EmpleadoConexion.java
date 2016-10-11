/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.SQLException;
import java.sql.Statement;
import modelo.Empleado;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class EmpleadoConexion extends Conexion<Empleado, Principal>{

    public EmpleadoConexion(Principal vista) {
        super(vista);
    }

    @Override
    public boolean inserta(Empleado modelo) throws ClassNotFoundException, SQLException {        
        //throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
        Statement stmt;
        int filasAfectadas = 0; // Aqui se alojara las columnas que fueron afectadas al momento de la inserción, en casos comunes solo se afecta 1
        String dml = String.format("INSERT INTO Persona.empleado (nombres, app, apm,fecha_nac,colonia,calle,numero,contraseña"+
                ") VALUES ('%s','%s','%s','%t','%s','%s',%d,'$s')",modelo.getNombres(),modelo.getApp(),modelo.getApp(),
                modelo.getFecha_nac(),modelo.getColonia(),modelo.getCalle(),modelo.getNumero(),modelo.getContraseña()); // Cadena de formato de la consulta
        
        super.realizaConexion(); // Realiza conexion con la base de datos
        stmt = super.db.createStatement();
        filasAfectadas = stmt.executeUpdate(dml);
        super.cierraConexion();
        return true;
    }

    @Override
    public boolean elimina(Empleado modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean actualiza(Empleado modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    
}
