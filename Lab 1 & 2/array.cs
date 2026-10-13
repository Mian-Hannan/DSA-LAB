using System;
using System.Reflection;
using System.Runtime.CompilerServices;

class ArrayOperations
{
    private readonly int[] _arr;
    private int _size;
    public int Capacity { get; }

    public ArrayOperations(int capacity = 15)
    {
        Capacity = capacity;
        _arr = new int[capacity];
        _size = 0;
    }

    public int Size => _size;

    public int[] snapshot()
    {
        var copy = new int[_size];
        Array.Copy(_arr, copy, _size);
        return copy;
    }

    public bool insertAtStart(int value)
    {
        if (_size >= Capacity) return false;

        for (int i = _size; i > 0; i--)
        {
            _arr[i] = _arr[i - 1];
        }
        _arr[0] = value;
        _size++;       // _size++ to make latest snapshot of in use elemnts array
        return true;
    }

    public bool insertAtEnd(int value)
    {
        if (_size >= Capacity) return false;
        _arr[_size] = value;    //because _size = length and length = last idx + 1
        _size++;     //for latest snapshot , bcz snapshot use copy method
        return true;    
    }

    public bool insertAtMiddle(int position, int value)
    {
        if (position > _size || position < 0) {
            Console.WriteLine($"Position out of rangee. Valid from 0 to {_size}");
            return false;
        }
        if (_size >= Capacity)
        {
            Console.WriteLine("Overflow: array is full");
            return false;
        }

        for(int i = _size; i > position; i--)
        {
            _arr[i] = _arr[i - 1];
        }
        _arr[position] = value;
        _size++;
        return true;
    }

    public bool insertAfterSpecificVal(int val, int specificVal)
    {
        if (_size >= Capacity)
        {
            Console.WriteLine("Overflow: array is full");
            return false;
        }
        int idx = 0;
        for(int i = 0; i <= _size; i++)
        {
            if(_arr[i] == specificVal) {
                idx = i;
                
            }
        }
        for(int i = _size; i > idx; i--) _arr[i] = _arr[i - 1];
        _arr[idx + 1] = val;
        _size++;
        return true;
    }

    public bool deleteAtStart()
    {
        if (_size == 0) return false;

        for(int i = 0; i < _size; i++)
        {
            _arr[i] = _arr[i + 1];  //Shifting from right to left
        }

        _size--;
        return true;
    }


    public bool deleteAtEnd()
    {
        if(_size == 0) return false;

        _arr[_size] = 0;
        _size--;
        return true;
    }

    public bool deleteAtMiddle(int position)
    {
        if(position > _size || position < 0)
        {
            Console.WriteLine($"Position out of rangee. Valid from 0 to {_size}");
            return false;
        }
        for(int i = position; i < _size; i++)
        {
            _arr[i] = _arr[i + 1];
        }
        _size--;
        return true;
    }

    public bool updateAtPosition(int pos, int value)
    {
        if(pos >= _size || pos < 0)
        {
            Console.WriteLine($"Invalid position, Valid range from 0 to {_size - 1}");
            return false;
        }
        _arr[pos] = value;
        return true;
    }
    public void displayArray()
    {
        foreach(var el in snapshot())
        {
            Console.Write(el + " ");
        }
        Console.WriteLine("\n");
    }

}

class Program
{
    static void Main()
    {
        ArrayOperations arr = new ArrayOperations(10);
        arr.insertAtStart(20);
        arr.displayArray();
        arr.insertAtEnd(32);
        arr.displayArray();
        arr.insertAtMiddle(1, 29);
        arr.displayArray();
        arr.insertAfterSpecificVal(67, 20);
        arr.displayArray();
        arr.updateAtPosition(1, 98);
        arr.displayArray();

        // arr.deleteAtEnd();
        // arr.displayArray();
        // arr.deleteAtStart();
        // arr.displayArray();
        
        arr.deleteAtMiddle(2);
        arr.displayArray();
        Console.WriteLine($"Current size of array is: {arr.snapshot().Length}");
    }
}