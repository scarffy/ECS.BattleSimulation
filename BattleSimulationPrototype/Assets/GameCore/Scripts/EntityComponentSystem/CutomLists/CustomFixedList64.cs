using Unity.Burst;
using Unity.VisualScripting;

[BurstCompile]
public unsafe struct CustomFixedList64<T> where T : unmanaged
{

    private readonly T m_Element0;
    private readonly T m_Element1;
    private readonly T m_Element2;
    private readonly T m_Element3;
    private readonly T m_Element4;
    private readonly T m_Element5;
    private readonly T m_Element6;
    private readonly T m_Element7;
    private readonly T m_Element8;
    private readonly T m_Element9;
    private readonly T m_Element10;
    private readonly T m_Element11;
    private readonly T m_Element12;
    private readonly T m_Element13;
    private readonly T m_Element14;
    private readonly T m_Element15;
    private readonly T m_Element16;
    private readonly T m_Element17;
    private readonly T m_Element18;
    private readonly T m_Element19;
    private readonly T m_Element20;
    private readonly T m_Element21;
    private readonly T m_Element22;
    private readonly T m_Element23;
    private readonly T m_Element24;
    private readonly T m_Element25;
    private readonly T m_Element26;
    private readonly T m_Element27;
    private readonly T m_Element28;
    private readonly T m_Element29;
    private readonly T m_Element30;
    private readonly T m_Element31;
    private readonly T m_Element32;
    private readonly T m_Element33;
    private readonly T m_Element34;
    private readonly T m_Element35;
    private readonly T m_Element36;
    private readonly T m_Element37;
    private readonly T m_Element38;
    private readonly T m_Element39;
    private readonly T m_Element40;
    private readonly T m_Element41;
    private readonly T m_Element42;
    private readonly T m_Element43;
    private readonly T m_Element44;
    private readonly T m_Element45;
    private readonly T m_Element46;
    private readonly T m_Element47;
    private readonly T m_Element48;
    private readonly T m_Element49;
    private readonly T m_Element50;
    private readonly T m_Element51;
    private readonly T m_Element52;
    private readonly T m_Element53;
    private readonly T m_Element54;
    private readonly T m_Element55;
    private readonly T m_Element56;
    private readonly T m_Element57;
    private readonly T m_Element58;
    private readonly T m_Element59;
    private readonly T m_Element60;
    private readonly T m_Element61;
    private readonly T m_Element62;
    private readonly T m_Element63;

    public ref T this[int index]
    {
        get
        {
            return ref GetElement(index);
        }
    }

    private ref T GetElement(int index)
    {
        fixed (T* elements = &this.m_Element0)
        {
            return ref elements[index];
        }
    }

    private void SetElement(int index, T value)
    {
        fixed (T* elements = &this.m_Element0)
        {
            elements[index] = value;
        }
    }

    public int Count { get; private set; }

    public const int Capacity = 64;

    public void Add(T item)
    {
        SetElement(this.Count, item);
        this.Count++;
    }

    public void Clear()
    {
        for (int i = 0; i < this.Count; ++i)
        {
            SetElement(i, default);
        }
        this.Count = 0;
    }

    public void Insert(int index, T value)
    {
        if (this.Count >= Capacity)
        {
            return;
        }
        for (int i = this.Count; i > index; --i)
        {
            SetElement(i, GetElement(i - 1));
        }
        SetElement(index, value);
        this.Count++;
    }

    public void RemoveAt(int index)
    {
        if (this.Count == 0)
        {
            return;
        }
        for (int i = index; i < this.Count - 1; ++i)
        {
            SetElement(i, GetElement(i + 1));
        }
        this.Count--;
    }

    public void RemoveRange(int index, int count)
    {

        if (count < 0)
        {
            return;
        }

        int indexAfter = index + count;
        int indexEndCopy = indexAfter + count;
        if (indexEndCopy >= this.Count)
        {
            indexEndCopy = this.Count;
        }

        int numCopies = indexEndCopy - indexAfter;
        for (int i = 0; i < numCopies; ++i)
        {
            SetElement(index + i, GetElement(index + count + i));
        }

        for (int i = indexAfter; i < this.Count - 1; ++i)
        {
            SetElement(i, GetElement(i + 1));
        }

        this.Count -= count;
    }

    public void AssignAll(T value)
    {
        for(int i=0;i<Capacity;i++)
        {
            SetElement(i,value);
            Count++;
        }
    }

    public bool Contains(T value)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (GetElement(i).Equals(value))
                return true;
        }
        return false;
    }

    public int GetIndex(T value)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (GetElement(i).Equals(value))
                return i;
        }
        return -1;
    }

}
