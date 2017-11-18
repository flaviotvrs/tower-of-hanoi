using System.Collections.Generic;

namespace TowerOfHanoi.Business
{
    public class Hanoi
    {
        int discos, move;
        Stack<int> origem, auxiliar, destino;

        public delegate void EventHandler(Stack<int> a, Stack<int> b, Stack<int> c, int move);
        public event EventHandler OnTransferDisk;

        public Hanoi(int numdiscos)
        {
            this.discos = numdiscos;
            this.move = 0;
            Init();
        }

        void Init()
        {
            origem = new Stack<int>(discos);
            auxiliar = new Stack<int>(discos);
            destino = new Stack<int>(discos);

            for (int i = 0; i < discos; i++)
                origem.Push(i + 1);
        }

        public int Start()
        {
            OnTransferDisk?.Invoke(origem, auxiliar, destino, move);

            Transfer(origem, destino, auxiliar, discos);
            return move;
        }

        private void Transfer(Stack<int> a, Stack<int> c, Stack<int> b, int n)
        {
            if (n == 1)
            {
                MoveDisc(a, c, b);
            }
            else
            {
                Transfer(a, b, c, n - 1);
                MoveDisc(a, c, b);
                Transfer(b, c, a, n - 1);
            }
        }

        private void MoveDisc(Stack<int> a, Stack<int> c, Stack<int> b)
        {
            move++;
            int d = a.Pop();
            c.Push(d);

            OnTransferDisk?.Invoke(origem, auxiliar, destino, move);
        }
    }
}
