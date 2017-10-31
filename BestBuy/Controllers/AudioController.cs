using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Enums;
using BestBuy.ViewModels.Audio_Video;
using BusinessLayer.Entity;

namespace BestBuy.Controllers
{
    public class AudioController : Controller
    {
        public IActionResult GetAllAudioDevices()
        {
            AudioDevices m = new AudioDevices();
            List<AudioDevices> audioDevicesList = m.GetAllAudioDevices();
            List<AudioDevicesViewModel> viewModel = new List<AudioDevicesViewModel>();

            foreach (AudioDevices entity in audioDevicesList)
            {
                AudioDevicesViewModel vModel = new AudioDevicesViewModel(entity.Brand,
                                                                         entity.MadeInCountry,
                                                                         entity.ProductionDate,
                                                                         entity.ModelName,
                                                                         entity.Color,
                                                                         entity.NumOfSpeakers,
                                                                         entity.Frequency,
                                                                         entity.USB,
                                                                         entity.RecordingSupport,
                                                                         entity.Bluetooth,
                                                                         entity.EchEffect,
                                                                         entity.CardReader,
                                                                         entity.FMRadio,
                                                                         entity.PlayingCD_R_RW,
                                                                         entity.WarrantyYears,
                                                                         entity.Price,
                                                                         entity.ImageAsBase64);
                viewModel.Add(vModel);
            }
            return View(viewModel);
        }

    }
}
