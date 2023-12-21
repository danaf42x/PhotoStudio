using PhotoStudio.BLL.Base;
using PhotoStudio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStudio.BLL.ViewModels.Pages.Sub
{
    public class PhotographersViewModel : BaseViewModel
    {
        public ObservableCollection<Photographer> ListPhotographers { get; set; }

        public PhotographersViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListPhotographers = new ObservableCollection<Photographer>(p.db.Photographers.GetAll());
        }
    }
}
