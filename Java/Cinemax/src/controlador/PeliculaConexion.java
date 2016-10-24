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
import modelo.Pelicula;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class PeliculaConexion extends Conexion<Pelicula> {

    @Override
    public boolean inserta(Pelicula modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("INSERT INTO Cine.pelicula (nombre,director,sinopsis,clasificacion,genero"+
                ") VALUES ('%s','%s','%s','%s','%s')",modelo.getNombre(),modelo.getDirector(),modelo.getSinopsis(),
                modelo.getClasificacion(),modelo.getGenero()); 
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean elimina(Pelicula modelo) {
        String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("DELETE FROM Cine.pelicula WHERE clave_pel = %d",modelo.getClave_pel());
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return (filasAfectadas > 0);
    }

    @Override
    public boolean actualiza(Pelicula modelo) {
       String sentencia;
        int filasAfectadas;
        
        sentencia = String.format("UPDATE Cine.pelicula SET nombre = '%s', director = '%s', sinopsis = '%s', clasificacion = '%s', genero = '%s' WHERE clave_pel = %d", 
                modelo.getNombre(), modelo.getDirector(), modelo.getSinopsis(), modelo.getClasificacion(), modelo.getGenero(), modelo.getClave_pel()); 
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
        
        consulta = "SELECT * FROM Cine.pelicula";
        
        try {
            return getModeloTabla(ejecutaConsulta(consulta));
        }
        catch(ClassNotFoundException | SQLException ex) {
            return null;
        }
    }

    @Override
    public void rellenaComboBox(JComboBox cb, String args[]) {
        if((args != null) && (args.length > 0)) {
            try {
                String consulta;
                Integer clave_cin;

                clave_cin = Integer.parseInt(args[0]);
                consulta = "SELECT distinct pelicula.nombre " +
                    "from Cine.funcion as funcion " + 
                    "INNER JOIN Cine.sala as sala on sala.clave_sal = funcion.clave_sal "+
                    "INNER JOIN Cine.cine as cine on cine.clave_cin = sala.clave_cin " + 
                    "INNER JOIN Cine.pelicula as pelicula on pelicula.clave_pel = funcion.clave_pel " +
                    "WHERE cine.clave_cin = " + clave_cin.toString();
                cb.removeAllItems();
                ResultSet rs = ejecutaConsulta(consulta);
                while(rs.next()) {
                    String nombreComppleto = rs.getString("nombre");
                    cb.addItem(nombreComppleto);
                }
            }
            catch(NumberFormatException | ClassNotFoundException | SQLException ex) {
                // TODO: ADD DATABASE LOG
            }
        }
    }
    
}
