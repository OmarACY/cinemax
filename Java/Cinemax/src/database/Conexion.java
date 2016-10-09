/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;

import java.sql.*;

/**
 *
 * @author MILAN
 * @param <T>
 */
public abstract class Conexion<T> {
    private Connection db;
    
    public Conexion(){
        db = null;
    }
    
    private void realizaConexion() throws ClassNotFoundException, SQLException {
        String nombreDriver  ="org.postgresql.Driver";
        int puerto = 5432;
        String baseDatos = "Cinemax";
        String url = String.format("jdbc:postgresql://localhost:%d/%s", puerto, baseDatos);
        // Usuario y Contraseña MILAN-PC 
        String nombreUsuario = "root";
        String contraseña = "toor";
        
        Class.forName(nombreDriver);
        db = DriverManager.getConnection(url, nombreUsuario, contraseña);
    }
    
    private void cierraConexion() throws SQLException{
        db.close();
        db = null;
    }
    
    public abstract boolean inserta(T modelo);
    public abstract boolean elimina(T modelo);
    public abstract boolean actualiza(T modelo);
}
