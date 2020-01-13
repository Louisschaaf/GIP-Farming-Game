﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Melon : MonoBehaviour, IInventoryItem
    {
        public string Name
        {
            get
            {
                return "Melon";
            }
        }


        public Sprite _Image = null;

        public Sprite Image
        {
            get
            {
                return _Image;
            }
        }

        public void OnPickup()
        {
            //Logica toevoegen wat er gebeurd wanneer de meloen opgepakt wordt door de speler
            gameObject.SetActive(false);
        }

    }

}