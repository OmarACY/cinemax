/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package vista;

import java.awt.Toolkit;

/**
 *
 * @author MILAN
 */
public class Principal extends javax.swing.JFrame {

    /**
     * Creates new form Principal
     */
    public Principal() {
        initComponents();
        setIcon();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        tpPrincipal = new javax.swing.JTabbedPane();
        panelAdministracion = new javax.swing.JPanel();
        tpAdministración = new javax.swing.JTabbedPane();
        panelEmpleados = new javax.swing.JTabbedPane();
        panelMembresia = new javax.swing.JPanel();
        panelPelicula = new javax.swing.JPanel();
        panelSucursal = new javax.swing.JPanel();
        panelFuncion = new javax.swing.JPanel();
        panelVentas = new javax.swing.JPanel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("Cinemax");
        setPreferredSize(new java.awt.Dimension(1000, 600));
        setResizable(false);

        jPanel1.setBackground(new java.awt.Color(255, 255, 255));

        tpAdministración.addTab("Empleado", panelEmpleados);

        javax.swing.GroupLayout panelMembresiaLayout = new javax.swing.GroupLayout(panelMembresia);
        panelMembresia.setLayout(panelMembresiaLayout);
        panelMembresiaLayout.setHorizontalGroup(
            panelMembresiaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 642, Short.MAX_VALUE)
        );
        panelMembresiaLayout.setVerticalGroup(
            panelMembresiaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 326, Short.MAX_VALUE)
        );

        tpAdministración.addTab("Membresía", panelMembresia);

        javax.swing.GroupLayout panelPeliculaLayout = new javax.swing.GroupLayout(panelPelicula);
        panelPelicula.setLayout(panelPeliculaLayout);
        panelPeliculaLayout.setHorizontalGroup(
            panelPeliculaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 642, Short.MAX_VALUE)
        );
        panelPeliculaLayout.setVerticalGroup(
            panelPeliculaLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 326, Short.MAX_VALUE)
        );

        tpAdministración.addTab("Película", panelPelicula);

        javax.swing.GroupLayout panelSucursalLayout = new javax.swing.GroupLayout(panelSucursal);
        panelSucursal.setLayout(panelSucursalLayout);
        panelSucursalLayout.setHorizontalGroup(
            panelSucursalLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 642, Short.MAX_VALUE)
        );
        panelSucursalLayout.setVerticalGroup(
            panelSucursalLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 326, Short.MAX_VALUE)
        );

        tpAdministración.addTab("Sucursal", panelSucursal);

        javax.swing.GroupLayout panelFuncionLayout = new javax.swing.GroupLayout(panelFuncion);
        panelFuncion.setLayout(panelFuncionLayout);
        panelFuncionLayout.setHorizontalGroup(
            panelFuncionLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 642, Short.MAX_VALUE)
        );
        panelFuncionLayout.setVerticalGroup(
            panelFuncionLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 326, Short.MAX_VALUE)
        );

        tpAdministración.addTab("Función", panelFuncion);

        javax.swing.GroupLayout panelAdministracionLayout = new javax.swing.GroupLayout(panelAdministracion);
        panelAdministracion.setLayout(panelAdministracionLayout);
        panelAdministracionLayout.setHorizontalGroup(
            panelAdministracionLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(tpAdministración)
        );
        panelAdministracionLayout.setVerticalGroup(
            panelAdministracionLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(tpAdministración, javax.swing.GroupLayout.Alignment.TRAILING)
        );

        tpPrincipal.addTab("Administración", panelAdministracion);

        javax.swing.GroupLayout panelVentasLayout = new javax.swing.GroupLayout(panelVentas);
        panelVentas.setLayout(panelVentasLayout);
        panelVentasLayout.setHorizontalGroup(
            panelVentasLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 647, Short.MAX_VALUE)
        );
        panelVentasLayout.setVerticalGroup(
            panelVentasLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 354, Short.MAX_VALUE)
        );

        tpPrincipal.addTab("Ventas", panelVentas);

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(tpPrincipal)
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(tpPrincipal)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Principal.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Principal.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Principal.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Principal.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(() -> {
            new Principal().setVisible(true);
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel panelAdministracion;
    private javax.swing.JTabbedPane panelEmpleados;
    private javax.swing.JPanel panelFuncion;
    private javax.swing.JPanel panelMembresia;
    private javax.swing.JPanel panelPelicula;
    private javax.swing.JPanel panelSucursal;
    private javax.swing.JPanel panelVentas;
    private javax.swing.JTabbedPane tpAdministración;
    private javax.swing.JTabbedPane tpPrincipal;
    // End of variables declaration//GEN-END:variables

    /**
     * This method sets the application icon
     */
    private void setIcon() {
        super.setIconImage(Toolkit.getDefaultToolkit().getImage(getClass().getResource("../imagenes/logo_oscuro.png")));
    }
}
