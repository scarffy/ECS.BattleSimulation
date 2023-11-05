using Unity.Burst;

[BurstCompile]
public unsafe struct CustomFixedList128<T> where T : unmanaged
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
    private readonly T m_Element64;
    private readonly T m_Element65;
    private readonly T m_Element66;
    private readonly T m_Element67;
    private readonly T m_Element68;
    private readonly T m_Element69;
    private readonly T m_Element70;
    private readonly T m_Element71;
    private readonly T m_Element72;
    private readonly T m_Element73;
    private readonly T m_Element74;
    private readonly T m_Element75;
    private readonly T m_Element76;
    private readonly T m_Element77;
    private readonly T m_Element78;
    private readonly T m_Element79;
    private readonly T m_Element80;
    private readonly T m_Element81;
    private readonly T m_Element82;
    private readonly T m_Element83;
    private readonly T m_Element84;
    private readonly T m_Element85;
    private readonly T m_Element86;
    private readonly T m_Element87;
    private readonly T m_Element88;
    private readonly T m_Element89;
    private readonly T m_Element90;
    private readonly T m_Element91;
    private readonly T m_Element92;
    private readonly T m_Element93;
    private readonly T m_Element94;
    private readonly T m_Element95;
    private readonly T m_Element96;
    private readonly T m_Element97;
    private readonly T m_Element98;
    private readonly T m_Element99;
    private readonly T m_Element100;
    private readonly T m_Element101;
    private readonly T m_Element102;
    private readonly T m_Element103;
    private readonly T m_Element104;
    private readonly T m_Element105;
    private readonly T m_Element106;
    private readonly T m_Element107;
    private readonly T m_Element108;
    private readonly T m_Element109;
    private readonly T m_Element110;
    private readonly T m_Element111;
    private readonly T m_Element112;
    private readonly T m_Element113;
    private readonly T m_Element114;
    private readonly T m_Element115;
    private readonly T m_Element116;
    private readonly T m_Element117;
    private readonly T m_Element118;
    private readonly T m_Element119;
    private readonly T m_Element120;
    private readonly T m_Element121;
    private readonly T m_Element122;
    private readonly T m_Element123;
    private readonly T m_Element124;
    private readonly T m_Element125;
    private readonly T m_Element126;
    private readonly T m_Element127;

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

    public const int Capacity = 128;

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
        for (int i = 0; i < Capacity; i++)
        {
            SetElement(i, value);
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
