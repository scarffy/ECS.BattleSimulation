using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public unsafe struct CustomFixedList256<T> where T : unmanaged
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
    private readonly T m_Element128;
    private readonly T m_Element129;
    private readonly T m_Element130;
    private readonly T m_Element131;
    private readonly T m_Element132;
    private readonly T m_Element133;
    private readonly T m_Element134;
    private readonly T m_Element135;
    private readonly T m_Element136;
    private readonly T m_Element137;
    private readonly T m_Element138;
    private readonly T m_Element139;
    private readonly T m_Element140;
    private readonly T m_Element141;
    private readonly T m_Element142;
    private readonly T m_Element143;
    private readonly T m_Element144;
    private readonly T m_Element145;
    private readonly T m_Element146;
    private readonly T m_Element147;
    private readonly T m_Element148;
    private readonly T m_Element149;
    private readonly T m_Element150;
    private readonly T m_Element151;
    private readonly T m_Element152;
    private readonly T m_Element153;
    private readonly T m_Element154;
    private readonly T m_Element155;
    private readonly T m_Element156;
    private readonly T m_Element157;
    private readonly T m_Element158;
    private readonly T m_Element159;
    private readonly T m_Element160;
    private readonly T m_Element161;
    private readonly T m_Element162;
    private readonly T m_Element163;
    private readonly T m_Element164;
    private readonly T m_Element165;
    private readonly T m_Element166;
    private readonly T m_Element167;
    private readonly T m_Element168;
    private readonly T m_Element169;
    private readonly T m_Element170;
    private readonly T m_Element171;
    private readonly T m_Element172;
    private readonly T m_Element173;
    private readonly T m_Element174;
    private readonly T m_Element175;
    private readonly T m_Element176;
    private readonly T m_Element177;
    private readonly T m_Element178;
    private readonly T m_Element179;
    private readonly T m_Element180;
    private readonly T m_Element181;
    private readonly T m_Element182;
    private readonly T m_Element183;
    private readonly T m_Element184;
    private readonly T m_Element185;
    private readonly T m_Element186;
    private readonly T m_Element187;
    private readonly T m_Element188;
    private readonly T m_Element189;
    private readonly T m_Element190;
    private readonly T m_Element191;
    private readonly T m_Element192;
    private readonly T m_Element193;
    private readonly T m_Element194;
    private readonly T m_Element195;
    private readonly T m_Element196;
    private readonly T m_Element197;
    private readonly T m_Element198;
    private readonly T m_Element199;
    private readonly T m_Element200;
    private readonly T m_Element201;
    private readonly T m_Element202;
    private readonly T m_Element203;
    private readonly T m_Element204;
    private readonly T m_Element205;
    private readonly T m_Element206;
    private readonly T m_Element207;
    private readonly T m_Element208;
    private readonly T m_Element209;
    private readonly T m_Element210;
    private readonly T m_Element211;
    private readonly T m_Element212;
    private readonly T m_Element213;
    private readonly T m_Element214;
    private readonly T m_Element215;
    private readonly T m_Element216;
    private readonly T m_Element217;
    private readonly T m_Element218;
    private readonly T m_Element219;
    private readonly T m_Element220;
    private readonly T m_Element221;
    private readonly T m_Element222;
    private readonly T m_Element223;
    private readonly T m_Element224;
    private readonly T m_Element225;
    private readonly T m_Element226;
    private readonly T m_Element227;
    private readonly T m_Element228;
    private readonly T m_Element229;
    private readonly T m_Element230;
    private readonly T m_Element231;
    private readonly T m_Element232;
    private readonly T m_Element233;
    private readonly T m_Element234;
    private readonly T m_Element235;
    private readonly T m_Element236;
    private readonly T m_Element237;
    private readonly T m_Element238;
    private readonly T m_Element239;
    private readonly T m_Element240;
    private readonly T m_Element241;
    private readonly T m_Element242;
    private readonly T m_Element243;
    private readonly T m_Element244;
    private readonly T m_Element245;
    private readonly T m_Element246;
    private readonly T m_Element247;
    private readonly T m_Element248;
    private readonly T m_Element249;
    private readonly T m_Element250;
    private readonly T m_Element251;
    private readonly T m_Element252;
    private readonly T m_Element253;
    private readonly T m_Element254;
    private readonly T m_Element255;

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

    public const int Capacity = 256;

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
