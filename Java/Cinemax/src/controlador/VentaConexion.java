/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controlador;

import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JComboBox;
import modelo.Venta;
import vista.Principal;

/**
 *
 * @author MILAN
 */
public class VentaConexion extends Conexion<Venta> {
    
    @Override
    public boolean inserta(Venta modelo) {
        boolean success = false;
        String sentencia;
        Long claveVenta;
        int filasAfectadas;

        sentencia = "INSERT INTO Venta.venta(total, clave_mem, clave_fun, clave_emp)" +
            "VALUES(0, " + modelo.getClave_mem() + ", " + modelo.getClave_fun() + ", " + modelo.getClave_emp() + ")";
        
        try {
            filasAfectadas = ejecutaSentencia(sentencia);
            if(filasAfectadas > 0) {
                ResultSet rs = ejecutaConsulta("SELECT clave_ven FROM Venta.venta ORDER BY clave_ven desc limit 1");
                if(rs.next()) {
                    claveVenta = Long.parseLong(rs.getString("clave_ven"));
                    if (!modelo.isPago_efectivo())
                    {
                        sentencia = "INSERT INTO Venta.cuenta(clave_ven, numero_tar, codigo_seg, fecha_ven)" +
                            "VALUES(" + claveVenta.toString() + ", '" + modelo.getNumero_tar() + "', '" + modelo.getCodigo_seg() + "', '" + modelo.getFecha_ven() + "')";
                        ejecutaSentencia(sentencia);
                    }
                    
                    for (String butaca : modelo.getAsientos())
                    {
                        sentencia = "INSERT INTO Venta.detalle_venta(clave_ven, subtotal, asiento, tipo_asi)" +
                            "VALUES(" + claveVenta.toString() + ", " + modelo.getCostoAsiento().toString() + ", '" + butaca + "', '" + modelo.getTipoAsiento() + "')";
                        if (ejecutaSentencia(sentencia) <= 0)
                            break;
                    }
                }
                success = true;
            }
        }
        catch(ClassNotFoundException | SQLException ex) {
            filasAfectadas = 0;
        }
        return success;
    }

    @Override
    public boolean elimina(Venta modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public boolean actualiza(Venta modelo) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void rellenaComboBox(JComboBox cb, String args[]) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
