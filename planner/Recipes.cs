//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace planner
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipes()
        {
            this.IngrRecipe = new HashSet<IngrRecipe>();
        }
    
        public int IdRecipe { get; set; }
        public Nullable<int> IdCategory { get; set; }
        public string NameRecipe { get; set; }
        public byte[] ImgRecipe { get; set; }
        public string DescriptionRecipe { get; set; }
        public string StatusRecipe { get; set; }
    
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngrRecipe> IngrRecipe { get; set; }
    }
}
