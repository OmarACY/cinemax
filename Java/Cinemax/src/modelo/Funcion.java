/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

import java.sql.Time;
import java.util.Date;

/**
 *
 * @author MILAN
 */
public class Funcion {
    private long clave_fun;
    private long clave_pel;
    private long clave_sal;
    private Time hora_ini;
    private Time hora_fin;
    private Date fecha;

    public long getClave_fun() {
        return clave_fun;
    }

    public long getClave_pel() {
        return clave_pel;
    }

    public long getClave_sal() {
        return clave_sal;
    }

    public Time getHora_ini() {
        return hora_ini;
    }

    public Time getHora_fin() {
        return hora_fin;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setClave_pel(long clave_pel) {
        this.clave_pel = clave_pel;
    }

    public void setClave_sal(long clave_sal) {
        this.clave_sal = clave_sal;
    }

    public void setHora_ini(Time hora_ini) {
        this.hora_ini = hora_ini;
    }

    public void setHora_fin(Time hora_fin) {
        this.hora_fin = hora_fin;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }
}
