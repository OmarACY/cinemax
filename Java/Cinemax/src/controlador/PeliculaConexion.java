/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import modelo.Pelicula;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class PeliculaConexion extends Conexion<Pelicula, Principal> {

    public PeliculaConexion(Principal vista) {
        super(vista);
    }

    @Override
    public boolean inserta(Pelicula modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean elimina(Pelicula modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean actualiza(Pelicula modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
