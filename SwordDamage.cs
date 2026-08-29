using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageTester
{
    internal class SwordDamage
    {
        /// <summary>
        /// Константа для додавання до шкоди під час її вирахування (базова шкода).
        /// </summary>
        private const int BASE_DAMAGE = 3;
        /// <summary>
        /// Константа для додавання до шкоди під час її вирахування (додаткова шкода від вогняного ефекту).
        /// </summary>
        private const int FLAME_DAMAGE = 2;

        private int roll;
        /// <summary>
        /// Видає або задає результат кидку 3D6.
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }
        private bool flaming;
        /// <summary>
        /// Видає або задає вогняний ефект для меча.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }
        private bool magic;
        /// <summary>
        /// Видає або задає магічний ефект для меча.
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }
        /// <summary>
        /// Видає або задає значення вирахуваної шкоди від меча.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Вираховує значення шкоди по формулі, використовуючи значення Roll, Magic та Flaming
        /// (Якщо меч магічний, результат кидку множиться на 1.75; якщо меч вогняний, до вирахуваної шкоди додаються пошкодження від вогню).
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

        /// <summary>
        /// Задає початкове значення кидка 3D6 властивості Roll та вираховує початкову шкоду від меча.
        /// </summary>
        /// <param name="roll">Значення кидка 3D6.</param>
        public SwordDamage(int roll)
        {
            Roll = roll;
            CalculateDamage();
        }
    }
}
