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
    
    public partial class tb_viagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_viagem()
        {
            this.tb_ocorrencia = new HashSet<tb_ocorrencia>();
        }
    
        public int cod_viagem { get; set; }
        public int cod_motorista { get; set; }
        public int cod_cliente { get; set; }
        public int cod_veiculo { get; set; }
        public System.DateTime data_saida { get; set; }
        public System.DateTime prev_chegada { get; set; }
        public System.DateTime data_chegada { get; set; }
        public decimal valor { get; set; }
        public int NF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ocorrencia> tb_ocorrencia { get; set; }
        public virtual tb_pessoa tb_pessoa { get; set; }
        public virtual tb_pessoa tb_pessoa1 { get; set; }
        public virtual tb_veiculo tb_veiculo { get; set; }
    }
}
