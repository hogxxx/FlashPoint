using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OrderObject : MonoBehaviour
{
    private List<List<string>> order = new List<List<string>>();
    private static List<List<string>> Bio_7 = new List<List<string>>()
    {
        new List<string>
        {
            "������ �� ���������� � ������������� ������� �����",
            "�������� �� �������� �� ���������� ������ �� ���������� ����������",
            "���� �� �������� ��� ���� ���� ��������� � �����"
        },

        new List<string>
        {
            "���������� �� ���� ������� ������ � ����������",
            "̳������� �� �������� �� ���������� �� ���������� ������",
            "����������� �� �������� ������ ��� �����������"
        },

        new List<string>
        {
            "�������� �� �������� �� ���������� �� ������ ����",
            "������� �� ����� ����� � ��������� ��������",
            "��� �� ���� �������� ���������� � ��� �������"
        }
    };

    private static List<List<string>> Bio_8 = new List<List<string>>()
    {
        new List<string>
        {
            "����� �� ������� �������� �� ������ ����� �������",
            "������� ������ �� ����� ������ �� �������� �����",
            "���������� �� ������ ��������� ��������� �������"
        },

        new List<string>
        {
            "�������� ������� ��������� �������� �������� � ���������� �����������",
            "���������� ������� �� ����������� ������� ��������",
            "̒����� ������� ��������� ��� �������� � �������� �����"
        },

        new List<string>
        {
            "������ ������� �� ������� �� ������ ������� �� ��������",
            "���������� ������� �� ������� ������� ������ �������� ����� �������",
            "������� ������� �� ������� ��������� ��������"
        }
    };
    private static List<List<string>> Bio_9 = new List<List<string>>()
    {
        new List<string>
        {
            "��� �� ������� �������� ���������� � ���",
            "��������� �� ��������� � ��� � ���� � �����",
            "̳��� �� ���� ������ �� �� ������ � ��������� ������� ��������"
        },

        new List<string>
        {
            "����� �� ������ ����� ������ ��� ��������� �����",
            "����������� �� ���� �������� ��� �� �����������",
            "������� �� ��������� ������� ����� ��������"
        },

        new List<string>
        {
            "������� �� ��������� ���������� ��������",
            "������� �� ���� ��������� ���������� ��������",
            "�������� �� ������ ���������� ��� � ����� ���������"
        }
    };

    private static List<List<string>> Bio_10 = new List<List<string>>()
    {
        new List<string>
        {
            "��������� �� ����� �������� ������ ���� � ����������",
            "���������� �� ������� �����䳿 ����� �������� � ����������",
            "�������� �� ��������� ���������� ���� �� ������ �� ��� ��������"
        },

        new List<string>
        {
            "�������� �� ��������� ��������� � ������ ����������",
            "������ �������� �� ����������� �������� ����㳿 ����� ��������",
            "���������� �� �������� �� ��������� ������� ��������"
        },

        new List<string>
        {
            "���������� �� �������� �� ��������� ������ ����������",
            "��������� �� �������� �� ����������� ������ ������",
            "������� �� ����� ��� ������� �������� � ����������"
        }
    };

    private static List<List<string>> Bio_11 = new List<List<string>>()
    {
        new List<string>
        {
            "��������� �� �������� �������� ����������� ��������� ����",
            "������� �� �������� �������� ���������� �� ��������",
            "��������� ��� �� ��� �� ����� ���� � ���� ������"
        },

        new List<string>
        {
            "̳����������� �� �������� ����� ����� �� ����������",
            "�������� �� ������ ��������� ����� ����� ������ ��� ���� ������",
            "������������ �� ������������ ����� �������� ��� ��������� ��������"
        },

        new List<string>
        {
            "����� �������� �� �������� ��� �� ���� ��������",
            "������� �������� �� ��������� ������� ������ � �����",
            "�������� ���� �� ������ ��������� ��������� ����������"
        }
    };
    private static List<List<string>> Chem_7 = new List<List<string>>()
    {
        new List<string>
        {
            "���� �� �������� �������� �������� ��������",
            "�������� �� �������� �� ���������� � �����",
            "ճ����� ������� �� ��������� ����� � ��������� �������"
        },

        new List<string>
        {
            "������� �� ������ ������������ ����� ������� � ����",
            "������ �� ������� ����� � ������ ����������",
            "���� �� �� ��� ����� ������� ��� �������� ��'����"
        },

        new List<string>
        {
            "ճ����� ��'���� �� ������� ����� � ���������",
            "��� �� ��������� �������� �� ����������� � �����",
            "���������� �� �������� �� ��������� ������ �������"
        }
    };

    private static List<List<string>> Chem_8 = new List<List<string>>()
    {
        new List<string>
        {
            "������� �� �������� �� ������� ���� �����",
            "������ �� �������� �� ������ ���� �����",
            "ѳ�� �� ������� ������� ������� � ������"
        },

        new List<string>
        {
            "������� ������������ �� ������� ������� � �������",
            "������ �� �������� ���� ���� ��� ����� �������",
            "��������� �� ������������ �������� � ������"
        },

        new List<string>
        {
            "��������� �� ������ ������ ��������� ������ ��� �����",
            "³��������� �� ������ ��������� ��������� ������",
            "ճ���� �������� �� ���� ������� ���� �������� ���"
        }
    };

    private static List<List<string>> Chem_9 = new List<List<string>>()
    {
        new List<string>
        {
            "�������� ���� �� ����� ��� ������� �������",
            "������ �� ������� ��������� � ���������� ��'������",
            "������ �� ��������� ��������� � ��������� ��'������"
        },

        new List<string>
        {
            "����� �� ��������� ��������� � ��������� ��'������",
            "��������� ������� �� ������� �������� � ���������� ������",
            "������� �� ��������� ������ � ��������� �������� ��� ����� �������"
        },

        new List<string>
        {
            "������� �� �������� � �������� ���������� �� ������������",
            "����� �� ������� �������� � ����������",
            "��������� �� ������� ������� � ������� ����� � �����"
        }
    };

    private static List<List<string>> Chem_10 = new List<List<string>>()
    {
        new List<string>
        {
            "���������� �� �������� �� ��������� ����������� ����� � ������",
            "������������ �� �������� �� �� ��������� �����",
            "������������ ������� �� ������� �� ������ ���������"
        },

        new List<string>
        {
            "������� �������� �� ������ ������� �������� �� �������",
            "������� ���������� �� ��������� ������� �������� � ��������",
            "����������� �� ������� ������ �����䳿 � ������"
        },

        new List<string>
        {
            "�������� �� �������� ����� ������ �������",
            "������ �� ����������� ������ ������� �� ��������� �����������",
            "������� �������� �� ������ ����� ����� � �������"
        }
    };

    private static List<List<string>> Chem_11 = new List<List<string>>()
    {
        new List<string>
        {
            "������� �� ����� ��� ����� ������� � ����� ���������",
            "��� �� ��������� ������� �� ���� �������� ����������",
            "��� �� �������� �� ���� ������ � ������ ����"
        },

        new List<string>
        {
            "�������� �� ���� �� ���������� ������� �������",
            "˳��� �� ������� �������� � �������� ������������",
            "����������� �� ������ ��� �������� ����"
        },

        new List<string>
        {
            "���������� �� ������ ��������� ��������� ������� �� ��2",
            "���������� ������� �� ������ ������� �� ������ ��2",
            "������-������� �� ������-������ ����� �������"
        }
    };
    private static List<List<string>> Phys_7 = new List<List<string>>()
    {
        new List<string>
        {
            "��������� ��� �� ���� ��������� ��� � �������",
            "�������� �� ������� �������� �� ������� ��� ���",
            "���� �� �������, �� ����� ��� ���"
        },

        new List<string>
        {
            "����������� �� ���� �������� ���� � �����",
            "���� �� ������� �������� �� ������� ������� ��������",
            "��������� �� ���� ���������� �� ����� � ������"
        },

        new List<string>
        {
            "���� �� ���� ��� 䳺 �� ������� �����",
            "������ �� �������� ��� ���������� ������",
            "г������� ���� �� ����� ������ ��� ���� �����"
        }
    };
    private static List<List<string>> Phys_8 = new List<List<string>>()
    {
        new List<string>
        {
            "����������� ����� �� ��� ���������� �������� � ���������",
            "������� �� ������� �������� �� ������� ������ ������",
            "���� ������ �� ������� ������ �� ��������� �� ���"
        },

        new List<string>
        {
            "��� �� ������� �������� �� ���������� ������ � ���������",
            "������� ���� �� ���� �� ����������� ����������� �������",
            "����� ��� �� ������������ �� �������� � �������"
        },

        new List<string>
        {
            "�������������� �������� �� ����� ���������� ������ � ���������",
            "�������� �� ����� ������ ��������� �������� ��������",
            "�������� ��� �� ��������� ��� ������� � �������"
        }
    };

    private static List<List<string>> Phys_9 = new List<List<string>>()
    {
        new List<string>
        {
            "����� �� �������������� ����� ��� ������� ���",
            "���������� ����� �� ������ ��������� ���� ������������",
            "���������� ����� �� ���� �������� ���� ���������"
        },

        new List<string>
        {
            "�������� �� ����������� ����� �� ���������� �������",
            "������ ���� �� ������� ���� �� ���������������� � ����������",
            "���������� ����� �� ������ ������� �� �������� ��������"
        },

        new List<string>
        {
            "������������� �� ������ ����������� ������� ���� �����",
            "�����-������������� �� ���� ���� ���� �� ��������� ����",
            "������� ������ �� ������ ������ ������ ���� � �����"
        }
    };

    private static List<List<string>> Phys_10 = new List<List<string>>()
    {
        new List<string>
        {
            "������� �� �������� �� ����������� ��� ���",
            "����� ���������� ����㳿 �� ��������������� ������� ������",
            "����� ������� �� ��� ������ ������ �������"
        },

        new List<string>
        {
            "�������� ��������� �� ��� �� ������������ ����� ��� ������� ����",
            "����� ������ �� ����� �����䳿 ���������� ��������",
            "������������ �� ����� ��� ����� � ������"
        },

        new List<string>
        {
            "�������� ������ �� ������� �� ���������� ����� � ������",
            "����� ������� �� ����� �������������� �������� � ���������",
            "�������������� ����� �� ��������� ������� ���������������� ����"
        }
    };

    private static List<List<string>> Phys_11 = new List<List<string>>()
    {
        new List<string>
        {
            "�������� ������� �� ������ �������� � �������� ��������",
            "������������� ������� �� ����� ������ �� ������� �������� �����",
            "����� �� �������� ����� ��� ���������� ������"
        },

        new List<string>
        {
            "����� �������� �� ���������� ������ �� ��������� ��������",
            "������ ������ �� ������ �� ������������ � ���� �����",
            "������� �� ��� ���������������� ������� � ������������"
        },

        new List<string>
        {
            "����� �� ������� ��� ��������� ������������ �����",
            "������ �� ���� �������� � ������� ����������� � ������",
            "����� ������ �� ���� ��������� ����㳿 �� ������� �������������"
        }
    };
    private static List<List<string>> IT_7 = new List<List<string>>()
    {
        new List<string>
        {
            "���������� �� ������� ��������� �� ����� �� �������",
            "��� �� ����� �� ������ ���� ����������",
            "�������� �� ���� ���������� �� ������ ����'����"
        },

        new List<string>
        {
            "�������� �� ����������� �� ��� �������� ������",
            "����'���� �� ����������� ������� ��� ������� �����",
            "���� �� ���� ����� ���������� �� ��� ����������"
        },

        new List<string>
        {
            "���������� ������� �� �������� ��� ���� ������� ����'�����",
            "������ �� ����� ����'����� �� ������ ����������� ������",
            "���� ����� �� ����������� ��������� ���������� ��� �������� ������"
        }
    };
    private static List<List<string>> IT_8 = new List<List<string>>()
    {
        new List<string>
        {
            "��� �� �������� ������� ���������� � ����'����",
            "���� �� ������� ���������� ��� ���������� � 8 ���",
            "������������� �� ������ ��������� ������� ��� ����'�����"
        },

        new List<string>
        {
            "���� �� ������� ��� ���������� ������ ��",
            "����� �� ���� ����� ������ ���� � ����� ��'��",
            "������� �� ���� ���������� �� ������ ����� ������"
        },

        new List<string>
        {
            "����� �������㳿 �� ������ ��� ������� ����� � ��������",
            "�������� �� ��������� ������ �'������� ����'�����",
            "ʳ���������� �� ������ ��� ������� ���������� � �����"
        }
    };
    private static List<List<string>> IT_9 = new List<List<string>>()
    {
        new List<string>
        {
            "��������� ���������� �� ������������ ����� ��� �����������",
            "������� ������� �� ������� ������� � ������� ���",
            "���� ������������� �� ����� ��������� ��������� ��� ����'�����"
        },

        new List<string>
        {
            "�������� �� ������� ���'�� ��� ���������� ����� ���������",
            "��� ����� �� �������������� ����� ��� ���������� �������",
            "��������� �� ������ �������� ��������� ���� � ��������"
        },

        new List<string>
        {
            "����'������ ������� �� ��������� ��������� �� ��������� ����'�����",
            "������� ��� ����� �� �������� ��� ������ ������",
            "�������� ���������� �� ����� ������������� �������� ������"
        }
    };
    private static List<List<string>> IT_10 = new List<List<string>>()
    {
        new List<string>
        {
            "��'�����-��������� ������������� �� ������ � ��'������ � �������",
            "���� �� ������ ��� ��������� ��'���� � ���������� �������������",
            "��'��� �� ��������� ����� � ����������� ������������� �� ��������"
        },

        new List<string>
        {
            "������������ �� ������������ ������� ��'���� �� ���������� �������",
            "����������� �� �������� ������������ ����� �� ���� �������",
            "���������� �� ������������ ������ ���������� ��� ����� �����"
        },

        new List<string>
        {
            "������ �� ���������� ��� ��� ��������� ������������ �������",
            "��������� �������� �� ���� ������ ����� ������ � �����",
            "DNS �� ������� ���������� ������ � IP-�����"
        }
    };
    private static List<List<string>> IT_11 = new List<List<string>>()
    {
        new List<string>
        {
            "������� �������� �� �������� ����� ���������� ������ ������",
            "������� �������� �� �������� ��������� ��� ������ � ������",
            "�������� �� ��������� ��� ����������������� ��������� �����"
        },

        new List<string>
        {
            "�������� ����� �� ������ �������� � ������ ������ ����� ��������",
            "³�������� ��������� �� ��������� ���������� ���������� ���������",
            "��������� �� ������������ ����� � ��������� ����������� �������"
        },

        new List<string>
        {
            "��������� ����'���� �� ������� ��� ��������� �� ��������� ���������",
            "����� ��� �� ����� ������ ���������� ��� ������ � �������",
            "ʳ�������� �� ������� �������� ������ � �������������� �����������"
        }
    };
    private static List<List<string>> Math_7 = new List<List<string>>()
    {
        new List<string>
        {
            "��� �� ����� ������������ � ������ ������� ������",
            "����������� ����� �� ����� ��� ����� �������� ������",
            "��� �� ����������� ������ �������� ����� ���������"
        },

        new List<string>
        {
            "�������� �� ����������� �������� ��������� ������ ����� ����� ����",
            "��������� �� ������ ���� �������� �� �������",
            "������ �� ���������� ��������� �� ����� �������"
        },

        new List<string>
        {
            "г������ �� ����������� ���������� ��� ������ ���� ������",
            "������� �� �������� ������ �������� � �������",
            "������ ����� �� ������� ����� �� ���� �� ��"
        }
    };

    private static List<List<string>> Math_8 = new List<List<string>>()
    {
        new List<string>
        {
            "���������� ����� �� ����� ������� ����� ������� ������",
            "������������� ����� �� ����� ��� �� ����� �������� ������",
            "����������� �������� �� ����������� ����� � ������� ���������"
        },

        new List<string>
        {
            "������� �� ��������� �� ������� ������� ��������",
            "������ ������� �� ���������� ��������� ������ �� ����������� ������",
            "������� ������ �� ���� ������ ��� ����������� �������� ����'����"
        },

        new List<string>
        {
            "����������� ������� �� ������� ���� ��� ���������� ��������� �����",
            "��������� ������� �� ������� ������� ������� � ����������",
            "������� ������ �� ����� �������� ������ ������"
        }
    };

    private static List<List<string>> Math_9 = new List<List<string>>()
    {
        new List<string>
        {
            "������� �� �������� ���� ������� � ������ �����",
            "�������� �� ����� ��� ������ ������ ������ ��� ��������� �����",
            "ó�������� �� �������� ������� ������������ ����������"
        },

        new List<string>
        {
            "��������� �� ����������� ����� �� ���������� � ������ �������",
            "����������� �� �������� ���� ������� ������� ������ �������",
            "��� ������ �� ����� ��� ����� ������ �� �� ��� �������"
        },

        new List<string>
        {
            "��������� ������� �� ��������� �������� ���� ������� �� ������",
            "������� �� ����������� ���������� ��� ����� ������� ������",
            "������������ �� ����� ���������� ��� ���������� ������� �������"
        }
    };

    private static List<List<string>> Math_10 = new List<List<string>>()
    {
        new List<string>
        {
            "�������� �� �������� ���������� ����� �� �������� �������",
            "���������� �� ������� ������� a^x �� a ����� ����",
            "�������� �� ������ ����������� ������� ������� �������"
        },

        new List<string>
        {
            "������������ �� ����� ���������� ��� ���� � ����������",
            "����� ���� �� ��������� ������������ ������ �� ���������",
            "������� ���� �� ��������� ���������� ������ �� ���������"
        },

        new List<string>
        {
            "��������� �� ����� �� ��� ������ ������� ���������� �����������",
            "����������� ���� ����� �� ������� ����� �� ������������� �����",
            "����� ���� �� ����� �������� ����������� ������"
        }
    };

    private static List<List<string>> Math_11 = new List<List<string>>()
    {
        new List<string>
        {
            "�������������� ������� �� ������� �� ��������� ������� �������",
            "˳���� ������� �� ����� ���������� ��� ������� � �������",
            "��������� ������� �� ��������� �������� ���� �������"
        },

        new List<string>
        {
            "����������� ��������� �� ���������� ��������� �� �������� ����",
            "���䳺�� �� ������ �� ������ �������� ���������� ��������� �������",
            "����������� �� ����� ���� ��������� ������� ��� �������"
        },

        new List<string>
        {
            "�������� ��� �� ����������� �����, ��'������� � ����",
            "����� �� ����������� ��� �������� ���������� ����������",
            "���� �� ������� ����� ���� �������� ���� �� ������ �����"
        }
    };
    private static List<string> distractingWords_Bio = new List<string>
    {
        "������",
        "�����",
        "�������",
        "���",
        "��������",
        "���������",
        "������",
        "���",
        "���",
        "�������",
        "����������",
        "����",
        "����",
        "����",
        "���",
        "���",
        "�����",
        "���������",
        "���������",
        "���������",
        "����������",
        "���������",
        "���",
        "���������",
        "��������",
        "����������",
        "�������"
    };

    private static List<string> distractingWords_Chem = new List<string>
    {
        "����",
        "��������",
        "�������",
        "�������",
        "�������",
        "������",
        "����������",
        "������",
        "���������",
        "����������",
        "���������",
        "����������",
        "���",
        "���",
        "������",
        "������",
        "�����������",
        "�������",
        "����� �����",
        "������",
        "��������",
        "������� ��'����",
        "������ ������",
        "���",
        "����",
        "������",
        "�����������"
    };
    private static List<string> distractingWords_Phys = new List<string>
    {
        "����",
        "������",
        "�������",
        "����",
        "��������",
        "�����������",
        "����",
        "����",
        "�ᒺ�",
        "�����������",
        "�����",
        "���������",
        "�������",
        "������",
        "��������",
        "��������",
        "�����",
        "�����",
        "�����",
        "��������",
        "���",
        "���������",
        "�������",
        "��������",
        "�������",
        "�������",
        "�����"
    };
    private static List<string> distractingWords_IT = new List<string>
    {
        "����������",
        "���������",
        "������",
        "���'���",
        "�������",
        "��",
        "����",
        "������",
        "���������",
        "����",
        "�������",
        "����������",
        "��������",
        "���",
        "���",
        "�������",
        "���������",
        "��������",
        "����������",
        "������",
        "�����������",
        "�����",
        "��������",
        "���������",
        "�������",
        "�����",
        "���������"
    };
    private static List<string> distractingWords_Math = new List<string>
    {
        "�����",
        "�����",
        "������",
        "����������",
        "��������",
        "�����",
        "�ᒺ�",
        "�����",
        "���",
        "�������",
        "�������",
        "������",
        "�����������",
        "��������",
        "�������",
        "�������",
        "��������",
        "���������",
        "��������",
        "��������",
        "���������",
        "�������",
        "���������",
        "�����������",
        "��������",
        "��������",
        "���������"
    };

    public Button ready;
    public List<Toggle> toggles;
    public TextMeshProUGUI Choose;
    private List<string> subjects = new List<string>();
    private int classint;
    void Start()
    {
        classint = PlayerPrefs.GetInt("Class");
        foreach (Toggle order in toggles)
        {
            order.onValueChanged.AddListener(delegate { Changelist(); });
        }
        ready.onClick.AddListener(Save);
    }
    private void Changelist()
    {
        subjects.Clear();
        foreach (Toggle order in toggles)
        {
            if (order.isOn)
            {
                TextMeshProUGUI ObjectName = order.GetComponentInChildren<TextMeshProUGUI>(true);
                if (ObjectName != null)
                {
                    subjects.Add(ObjectName.text);
                }
            }
        }
    }
    private void Save()
    {
        if (subjects.Count > 0)
        {
            foreach (string lesson in subjects)
            {
                Check(lesson, classint);
            }
            FileManager.SaveOrder(order);
            PlayerPrefs.SetInt("Object", 0);
            PlayerPrefs.SetInt("Chooser", order.Count);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main");
        }
        else
        {
            StartCoroutine(Error());
        }
    }
    private IEnumerator Error()
    {
        Choose.text = "����� �������!";
        Choose.color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
        yield return new WaitForSeconds(1.5f);
        Choose.text = "����� �������";
        Choose.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
    private void Check(string name, int classint)
    {
        if (name == "Bio")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Bio_7);
                    break;
                case 8:
                    order = Connecter(order, Bio_8);
                    break;
                case 9:
                    order = Connecter(order, Bio_9);
                    break;
                case 10:
                    order = Connecter(order, Bio_10);
                    break;
                case 11:
                    order = Connecter(order, Bio_11);
                    break;
            }
        }
        else if (name == "Chem")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Chem_7);
                    break;
                case 8:
                    order = Connecter(order, Chem_8);
                    break;
                case 9:
                    order = Connecter(order, Chem_9);
                    break;
                case 10:
                    order = Connecter(order, Chem_10);
                    break;
                case 11:
                    order = Connecter(order, Chem_11);
                    break;
            }
        }
        else if (name == "Phys")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Phys_7);
                    break;
                case 8:
                    order = Connecter(order, Phys_8);
                    break;
                case 9:
                    order = Connecter(order, Phys_9);
                    break;
                case 10:
                    order = Connecter(order, Phys_10);
                    break;
                case 11:
                    order = Connecter(order, Phys_11);
                    break;
            }
        }
        else if (name == "IT")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, IT_7);
                    break;
                case 8:
                    order = Connecter(order, IT_8);
                    break;
                case 9:
                    order = Connecter(order, IT_9);
                    break;
                case 10:
                    order = Connecter(order, IT_10);
                    break;
                case 11:
                    order = Connecter(order, IT_11);
                    break;
            }
        }
        else if (name == "Math")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Math_7);
                    break;
                case 8:
                    order = Connecter(order, Math_8);
                    break;
                case 9:
                    order = Connecter(order, Math_9);
                    break;
                case 10:
                    order = Connecter(order, Math_10);
                    break;
                case 11:
                    order = Connecter(order, Math_11);
                    break;
            }
        }
    }
    private List<List<string>> Connecter(List<List<string>> order1, List<List<string>> adder)
    {
        int minnum = Mathf.Min(order1.Count, adder.Count);
        for (int i = 0; i < minnum; i++)
        {
            order1[i].AddRange(adder[i]);
        }
        for (int j = minnum; j < adder.Count; j++)
        {
            order1.Add(new List<string>(adder[j]));
        }
        return order1;
    }
    public static void CheckTerm(string term)
    {
        List<List<List<string>>> allLists_IT = new List<List<List<string>>> { IT_7, IT_8, IT_9, IT_10, IT_11 };
        if (SetList(term, allLists_IT, distractingWords_IT)) return;

        List<List<List<string>>> allLists_Math = new List<List<List<string>>> { Math_7, Math_8, Math_9, Math_10, Math_11 };
        if (SetList(term, allLists_Math, distractingWords_Math)) return;

        List<List<List<string>>> allLists_Phys = new List<List<List<string>>> { Phys_7, Phys_8, Phys_9, Phys_10, Phys_11 };
        if (SetList(term, allLists_Phys, distractingWords_Phys)) return;

        List<List<List<string>>> allLists_Chem = new List<List<List<string>>> { Chem_7, Chem_8, Chem_9, Chem_10, Chem_11 };
        if (SetList(term, allLists_Chem, distractingWords_Chem)) return;

        List<List<List<string>>> allLists_Bio = new List<List<List<string>>> { Bio_7, Bio_8, Bio_9, Bio_10, Bio_11 };
        if (SetList(term, allLists_Bio, distractingWords_Bio)) return;
    }
    public static bool SetList(string term, List<List<List<string>>> allLists,List<string> distractingWords)
    {
        foreach (List<List<string>> lister1 in allLists)
        {
            foreach (List<string> lister in lister1)
            {
                foreach (string termer in lister)
                {
                    if (termer.Split(" ")[0] == term)
                    {
                        DistructWords.distructwords = distractingWords;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
public static class DistructWords
{
    public static List<string> distructwords { get; set; } = new List<string>();
}
public static class FileManager
{
    private static string filepath;
    private static void InitializeFilePath()
    {
        if (string.IsNullOrEmpty(filepath))
        {
            filepath = Application.persistentDataPath + "/order.json";
        }
    }
    public static void SaveOrder(List<List<string>> orderlist)
    {
        InitializeFilePath();
        OrderLister orderlister = new OrderLister();
        foreach (var item in orderlist)
        {
            orderlister.orderlister1.Add(new SerializableList { Liber = item });
        }
        string json = JsonUtility.ToJson(orderlister, true);
        File.WriteAllText(filepath, json);
    }
    public static List<List<string>> LoadTerms()
    {
        InitializeFilePath();
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            OrderLister filegot = JsonUtility.FromJson<OrderLister>(json);
            List<List<string>> result = new List<List<string>>();
            if (filegot.orderlister1 != null && filegot != null)
            {
                foreach (var serialize in filegot.orderlister1)
                {
                    result.Add(serialize.Liber);
                }
            }
            return result;
        }
        else
        {
            return new List<List<string>>();
        }
    }
}
[System.Serializable]
public class SerializableList
{
    public List<string> Liber = new List<string>();
}
public class OrderLister
{
    public List<SerializableList> orderlister1 = new List<SerializableList>();
}