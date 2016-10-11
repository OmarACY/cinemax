/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

/**
 *
 * @author MILAN
 */
public class Pelicula {
    private long clave_pel;
    private String nombre;
    private String director;
    private String sinopsis;
    private String clasificacion;
    private String genero;

    public long getClave_pel() {
        return clave_pel;
    }

    public String getNombre() {
        return nombre;
    }

    public String getDirector() {
        return director;
    }

    public String getSinopsis() {
        return sinopsis;
    }

    public String getClasificacion() {
        return clasificacion;
    }

    public String getGenero() {
        return genero;
    }

    public void setClave_pel(long clave_pel) {
        this.clave_pel = clave_pel;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public void setSinopsis(String sinopsis) {
        this.sinopsis = sinopsis;
    }

    public void setClasificacion(String clasificacion) {
        this.clasificacion = clasificacion;
    }

    public void setGenero(String genero) {
        this.genero = genero;
    }
}
