/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JComboBox;
import modelo.Empleado;

/**
 *
 * @author MILAN
 */
public class LoginConexion extends Conexion<Empleado>{

    @Override
    public boolean inserta(Empleado modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean elimina(Empleado modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean actualiza(Empleado modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    public void rellenaComboBox(JComboBox cb, String args[]){
        String consulta;
        
        consulta = "SELECT * FROM Persona.empleado";
        try {
            cb.removeAllItems();
            ResultSet rs = ejecutaConsulta(consulta);
            while(rs.next()) {
                String nombreComppleto = rs.getString("nombres") + " " + rs.getString("app") + " " + rs.getString("apm");
                cb.addItem(nombreComppleto);
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            // TODO: ADD DATABASE LOG
        }
   }
    
}
