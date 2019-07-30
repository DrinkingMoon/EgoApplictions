using Ego.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ego.UIWpf.ViewModel
{
    public class DishViewModel
    {
        Dish _dish;

        bool _isSelected;
        public Dish Dish { get => _dish; set => _dish = value; }
        public bool IsSelected { get => _isSelected; set => _isSelected = value; }
    }
}
