//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestmove.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_locacao
    {
        public int cod_locacao { get; set; }
        public int cod_pessoa { get; set; }
        public int cod_veiculo { get; set; }
        public System.DateTime data_locacao { get; set; }
        public Nullable<System.DateTime> data_entrega { get; set; }
        public Nullable<int> qtd_dias { get; set; }
        public Nullable<int> km_original { get; set; }
        public Nullable<int> km_nova { get; set; }
        public decimal valor_locacao { get; set; }
        public int NF { get; set; }
    
        public virtual tb_pessoa tb_pessoa { get; set; }
        public virtual tb_veiculo tb_veiculo { get; set; }
    }
}
