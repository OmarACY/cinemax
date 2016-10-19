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
public class Cine {
    private long clave_cin;
    private String nombre;
    private String telefono;
    private int num_salas;
    private String colonia;
    private String calle;
    private int numero;

    public long getClave_cin() {
        return clave_cin;
    }

    public String getNombre() {
        return nombre;
    }
    
    public String getTelefono() {
        return telefono;
    }
        
    public int getNum_salas() {
        return num_salas;
    }

    public String getColonia() {
        return colonia;
    }

    public String getCalle() {
        return calle;
    }

    public int getNumero() {
        return numero;
    }
    
    public void setClave_cin(long clave_cin) {
        this.clave_cin = clave_cin;
    }
    
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public void setNum_salas(int num_salas) {
        this.num_salas = num_salas;
    }

    public void setColonia(String colonia) {
        this.colonia = colonia;
    }

    public void setCalle(String calle) {
        this.calle = calle;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }
}
