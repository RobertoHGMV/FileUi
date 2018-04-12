using System.Collections.Generic;

namespace FileUi.Domain.Models
{
    public class TransferType
    {
        private TransferType() { }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public static List<TransferType> GetTypes()
        {
            return new List<TransferType>
            {
                new TransferType{ Id = (int)TransferTypeEnum.None, Description = "Não definido" },
                new TransferType{ Id = (int)TransferTypeEnum.Copy, Description = "Copiar" },
                new TransferType{ Id = (int)TransferTypeEnum.Move, Description = "Mover" },
                new TransferType{ Id = (int)TransferTypeEnum.CopyAll, Description = "Copiar tudo" },
                new TransferType{ Id = (int)TransferTypeEnum.MoveAll, Description = "Mover tudo" }
            };
        }
    }

    public enum TransferTypeEnum
    {
        None = 0,
        Copy,
        Move,
        CopyAll,
        MoveAll
    }
}
