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
public class Venta {
    private long clave_ven;
    private float total;
    private long clave_mem;
    private long clave_fun;
    private long clave_emp;

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
}
