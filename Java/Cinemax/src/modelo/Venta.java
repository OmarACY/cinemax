/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.util.ArrayList;

/**
 *
 * @author MILAN
 */
public class Venta {
    private long clave_ven;
    private float total;
    private long clave_mem;
    private long clave_fun;
    private long clave_emp;
    private boolean pago_efectivo;
    private String numero_tar;
    private String codigo_seg;
    private String fecha_ven;
    private ArrayList<String> asientos;
    private Integer costoAsiento;
    private String tipoAsiento;

    public long getClave_ven() {
        return clave_ven;
    }

    public float getTotal() {
        return total;
    }

    public long getClave_mem() {
        return clave_mem;
    }

    public long getClave_fun() {
        return clave_fun;
    }

    public long getClave_emp() {
        return clave_emp;
    }

    public boolean isPago_efectivo() {
        return pago_efectivo;
    }

    public String getNumero_tar() {
        return numero_tar;
    }

    public String getCodigo_seg() {
        return codigo_seg;
    }

    public String getFecha_ven() {
        return fecha_ven;
    }

    public ArrayList<String> getAsientos() {
        return asientos;
    }

    public Integer getCostoAsiento() {
        return costoAsiento;
    }

    public String getTipoAsiento() {
        return tipoAsiento;
    }

    public void setClave_ven(long clave_ven) {
        this.clave_ven = clave_ven;
    }

    public void setTotal(float total) {
        this.total = total;
    }

    public void setClave_mem(long clave_mem) {
        this.clave_mem = clave_mem;
    }

    public void setClave_fun(long clave_fun) {
        this.clave_fun = clave_fun;
    }

    public void setClave_emp(long clave_emp) {
        this.clave_emp = clave_emp;
    }

    public void setPago_efectivo(boolean pago_efectivo) {
        this.pago_efectivo = pago_efectivo;
    }

    public void setNumero_tar(String numero_tar) {
        this.numero_tar = numero_tar;
    }

    public void setCodigo_seg(String codigo_seg) {
        this.codigo_seg = codigo_seg;
    }

    public void setFecha_ven(String fecha_ven) {
        this.fecha_ven = fecha_ven;
    }

    public void setAsientos(ArrayList<String> asientos) {
        this.asientos = asientos;
    }

    public void setCostoAsiento(Integer costoAsiento) {
        this.costoAsiento = costoAsiento;
    }

    public void setTipoAsiento(String tipoAsiento) {
        this.tipoAsiento = tipoAsiento;
    }
}
