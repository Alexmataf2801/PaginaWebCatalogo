using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Index
    {
        public List<ImagenesProducto> ListaProductos = new List<ImagenesProducto>();
        public ImagenesProducto imagenesProducto = new ImagenesProducto();
        public Usuario usuario = new Usuario();
        public List<RedesSociales> ListaRedesSociales = new List<RedesSociales>();
        public Empresa Empresa = new Empresa();
        public List<ImagenesProducto> ListaProductosDescuento = new List<ImagenesProducto>();

    }
}
