using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace steam_idle_gui
{
    class KonamiSequence
    {
        List<Keys> Keys = new List<Keys>{System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Up, 
                                       System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Down, 
                                       System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, 
                                       System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, 
                                       System.Windows.Forms.Keys.B, System.Windows.Forms.Keys.A};
        private int mPosition = -1;

        public bool IsCompletedBy(System.Windows.Forms.Keys key)
        {
            if (((System.Windows.Forms.Keys)this.Keys[this.Position + 1]) == key)
            {
                this.Position++;
            }
            else if ((this.Position != 1) || (key != System.Windows.Forms.Keys.Up))
            {
                if (((System.Windows.Forms.Keys)this.Keys[0]) == key)
                {
                    this.Position = 0;
                }
                else
                {
                    this.Position = -1;
                }
            }
            if (this.Position == (this.Keys.Count - 1))
            {
                this.Position = -1;
                return true;
            }
            return false;
        }

        public int Position
        {
            get
            {
                return this.mPosition;
            }
            private set
            {
                this.mPosition = value;
            }
        }
    }
}
