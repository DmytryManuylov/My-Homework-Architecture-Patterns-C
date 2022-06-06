using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
    class PlayerShooting
    {
        public IWeapon weapon { get; set; }
        public void shoot() { weapon.shoot(); }
    }
}
