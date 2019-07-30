using Ego.Application;
using Ego.Domain.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Ego.UIWpf.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        RestaurantApp _app_Restaurant = new RestaurantApp();

        DishViewModel _vm_SelectedDish;
        double _count;
        string _name;
        Restaurant _rest;
        ObservableCollection<DishViewModel> _ob_vm_Dish = new ObservableCollection<DishViewModel>();

        public DishViewModel Vm_SelectedDish { get => _vm_SelectedDish; set => _vm_SelectedDish = value; }
        public double Count { get => _count; set => _count = value; }
        public ObservableCollection<DishViewModel> Ob_vm_Dish { get => _ob_vm_Dish; set => _ob_vm_Dish = value; }
        public Restaurant Rest { get => _rest; set => _rest = value; }

        public ICommand SelectCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Count = Ob_vm_Dish.Where(k => k.IsSelected == true).Count();
                });
            }
        }

        public ICommand AddItemCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    DishViewModel addDvm = new DishViewModel() { Dish = new Dish(), IsSelected = false, };
                    Ob_vm_Dish.Add(addDvm);
                    Vm_SelectedDish = addDvm;
                });
            }
        }

        public ICommand RemoveItemCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Ob_vm_Dish.Remove(Vm_SelectedDish);
                });
            }
        }

        public ICommand SubmitComman
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _rest.Dishes = new List<Dish>();
                    _ob_vm_Dish.ToList().ForEach(k => { _rest.Dishes.Add(k.Dish); });
                    _app_Restaurant.Save(_rest);

                    Messenger.Default.Send<string>("提交信息", "Submit");

                });
            }
        }

        public MainViewModel()
        {
            InitForm();
        }

        void InitForm()
        {
            _rest = _app_Restaurant.GetItem();

            if (_rest == null)
            {
                _rest = new Restaurant();
            }

            _rest.Dishes.ToList().ForEach(k=> {
                DishViewModel dishViewModel = new DishViewModel()
                {
                    Dish = k,
                    IsSelected = false
                };

                _ob_vm_Dish.Add(dishViewModel);
            });
        }
    }
}