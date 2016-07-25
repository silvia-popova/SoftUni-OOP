using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Models
{
    public class BlobplodeAttack : Attack
    {
        public BlobplodeAttack(int damage) : base(damage)
        {
        }
    }
}
