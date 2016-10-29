/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package modelo;

/**
 *
 * @author OmarACY
 */
public class Sala {
    int clave_sal;
    int cupo;
    
    public int getClaveSala(){
        return clave_sal;
    }
    
    public int getCupo(){
        return cupo;
    }
    
    public void setClaveSala(int clave_sal){
        this.clave_sal = clave_sal;
    }
    
    public void setCupo(int cupo){
        this.cupo = cupo;
    }
}
