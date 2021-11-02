﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Praktika.Infrastructures.Commands;
using Praktika.Models;
using Praktika.Services;

namespace Praktika.Viewmodels
{
    public sealed class DataPageViewModel : BaseViewModel
    {
        public DataPageViewModel()
        {
            Videocards = new ObservableCollection<Videocard>(DataWorker.GetAllVideocards());

            StatusModalCommand = new LambdaCommand(OnStatusModalCommandExecuted, CanStatusModalCommandExecute);

            AddNewVideocardCommand = new LambdaCommand(OnAddNewVideocardExecuted, CanAddNewVideocardExecute);

            DeleteVideocardCommand = new LambdaCommand(OnDeleteVideocardExecuted, CanDeleteVideocardExecute);

            

            Companys = new List<Company>
            {
                new Company {Name = "Amd"},
                new Company {Name = "Nvidia"},
                new Company {Name = "Intel"}
            };

            MemoryTypes = new List<MemoryType>
            {
                new MemoryType {Name = "GDDR3"},
                new MemoryType {Name = "GDDR4"},
                new MemoryType {Name = "GDDR5"},
                new MemoryType {Name = "GDDR5X"},
                new MemoryType {Name = "GDDR6"},
                new MemoryType {Name = "GDDR6X"},
                new MemoryType {Name = "HBM2"},
                new MemoryType {Name = "HBM3"}
            };

            Interfaces = new List<Interface>
            {
                new Interface {Name = "AGP 4x"},
                new Interface {Name = "AGP 8x"},
                new Interface {Name = "PCI-e 3.0 x4"},
                new Interface {Name = "PCI-e 3.0 x16"},
                new Interface {Name = "PCI-e 4.0 x4"},
                new Interface {Name = "PCI-e 4.0 x16"},
                new Interface {Name = "PCI-e 5.0 x4"},
                new Interface {Name = "PCI-e 5.0 x16"}
            };
        }

        public ObservableCollection<Videocard> Videocards { get; set; }

        public List<Company> Companys { get; }

        public List<MemoryType> MemoryTypes { get; }

        public List<Interface> Interfaces { get; }

        #region Методы

        private bool CheckParametrs()
        {
            return !string.IsNullOrEmpty(VideocardName) && !string.IsNullOrEmpty(VideocardCore) &&
                   !(VideocardTechProcess == default) && !(SelectedCompany == default) &&
                   !(SelectedMemoryType == default) &&
                   !(SelectedInterface == default);
        }

        private void removeparametrs()
        {
            if (!AddVisibility)
            {
                SelectedCompany = default;
                SelectedInterface = default;
                SelectedMemoryType = default;
                VideocardName = null;
                VideocardTechProcess = default;
                VideocardCore = null;
            }
        }

        #endregion

        #region Команды

        #region Открытие модального окна для добавления

        public ICommand StatusModalCommand { get; }

        private bool CanStatusModalCommandExecute(object p) => true;
        
        private void OnStatusModalCommandExecuted(object p)
        {
            
            AddVisibility = Convert.ToBoolean(p);
            removeparametrs();
        }

        #endregion

        #region Добавление новой видеокарты

        public ICommand AddNewVideocardCommand { get; }

        private bool CanAddNewVideocardExecute(object p)
        {
            return CheckParametrs();
        }

        private void OnAddNewVideocardExecuted(object p)
        {
            var ResultVideocardID = DataWorker.CreateVideocard(_SelectedCompany.Name, _VideocardName, _VideocardCore,
                _VideocardTechProcess,
                _SelectedMemoryType.Name, _SelectedInterface.Name);

            //Временная заплатка чтобы сильной нагрузки не было
            if (ResultVideocardID != default)
            {
                Videocards.Add(new Videocard
                {
                    Company = _SelectedCompany.Name,
                    Core = VideocardCore,
                    Interface = _SelectedInterface.Name,
                    ID = ResultVideocardID, 
                    MemoryType = _SelectedMemoryType.Name, 
                    Name = VideocardName,
                    TechProcess = VideocardTechProcess
                });
                AddVisibility = false;
                removeparametrs();
            }
        }

        #endregion

        #region Удаление видеокарты


        public ICommand DeleteVideocardCommand { get; }

        private bool CanDeleteVideocardExecute(object p) => p is Videocard;

        private void OnDeleteVideocardExecuted(object p)
        {
            if (DataWorker.DeleteVideoCard(_SelectedCard))
            {
                Videocards.Remove(_SelectedCard);
            }
        }

        #endregion


        #endregion

        #region Данные с формы

        private Videocard _SelectedCard;

        public Videocard SelectedCard
        {
            get => _SelectedCard;
            set => Set(ref _SelectedCard, value);
        }

        private bool _AddVisibility;

        public bool AddVisibility
        {
            get => _AddVisibility;
            set => Set(ref _AddVisibility, value);
        }


        #endregion

        #region Данные для добавления новой карты

        private Company _SelectedCompany;

        public Company SelectedCompany
        {
            get => _SelectedCompany;
            set => Set(ref _SelectedCompany, value);
        }

        private MemoryType _SelectedMemoryType;

        public MemoryType SelectedMemoryType
        {
            get => _SelectedMemoryType;
            set => Set(ref _SelectedMemoryType, value);
        }


        private Interface _SelectedInterface;

        public Interface SelectedInterface
        {
            get => _SelectedInterface;
            set => Set(ref _SelectedInterface, value);
        }

        private string _VideocardName;

        public string VideocardName
        {
            get => _VideocardName;
            set => Set(ref _VideocardName, value);
        }

        private string _VideocardCore;

        public string VideocardCore
        {
            get => _VideocardCore;
            set => Set(ref _VideocardCore, value);
        }

        private byte _VideocardTechProcess;

        public byte VideocardTechProcess
        {
            get => _VideocardTechProcess;
            set => Set(ref _VideocardTechProcess, value);
        }

        #endregion
    }
}