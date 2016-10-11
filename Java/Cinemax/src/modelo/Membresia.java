/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.Date;

/**
 *
 * @author MILAN
 */
public class Membresia {
    private long clave_mem;
    private String nombre;
    private String app;
    private String apm;
    private Date fecha_nac;
    private String colonia;
    private String calle;
    private int numero;
    private String tipo;
    private int puntos;

    public long getClave_mem() {
        return clave_mem;
    }

    public String getNombre() {
        return nombre;
    }

    public String getApp() {
        return app;
    }

    public String getApm() {
        return apm;
    }

    public Date getFecha_nac() {
        return fecha_nac;
    }

    public void setClave_mem(long clave_mem) {
        this.clave_mem = clave_mem;
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

    public String getTipo() {
        return tipo;
    }

    public int getPuntos() {
        return puntos;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public void setApp(String app) {
        this.app = app;
    }

    public void setApm(String apm) {
        this.apm = apm;
    }

    public void setFecha_nac(Date fecha_nac) {
        this.fecha_nac = fecha_nac;
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

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public void setPuntos(int puntos) {
        this.puntos = puntos;
    }
}
