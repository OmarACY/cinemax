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
public class Empleado{
    private long clave_emp;
    private String nombres;
    private String app;
    private String apm;
    private Date fecha_nac;
    private String colonia;
    private String calle;
    private Integer numero;
    private String contraseña;
    public String nombre_rol;

    public long getClave_emp() {
        return clave_emp;
    }

    public String getNombres() {
        return nombres;
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

    public String getColonia() {
        return colonia;
    }

    public String getCalle() {
        return calle;
    }

    public Integer getNumero() {
        return numero;
    }

    public String getContraseña() {
        return contraseña;
    }

    public String getNombre_rol() {
        return nombre_rol;
    }

    public void setClave_emp(long clave_emp) {
        this.clave_emp = clave_emp;
    }

    public void setNombres(String nombres) {
        this.nombres = nombres;
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

    public void setNumero(Integer numero) {
        this.numero = numero;
    }

    public void setContraseña(String contraseña) {
        this.contraseña = contraseña;
    }

    public void setNombre_rol(String nombre_rol) {
        this.nombre_rol = nombre_rol;
    }
}
