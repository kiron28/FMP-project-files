using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EncounterTables : MonoBehaviour
{
    [SerializeField] List<EnemyEncounterRecord> monsterList;

    void Start()
    {
        int ttlchance = 0;
        foreach (var record in monsterList)
        {
            record.lwrchance = ttlchance;
            record.upprchance = ttlchance + record.chancepcnt;

            ttlchance = ttlchance + record.chancepcnt;
        }
    }


    public Enemy GetRandomMonster()
    {
        int randomval = Random.Range(1, 101);
        var Record = monsterList.First(p => randomval >= p.lwrchance && randomval <= p.upprchance);

        var levelRange = Record.levelRange;
        int lvl = levelRange.y == 0 ? levelRange.x : Random.Range(levelRange.x, levelRange.y + 1);

        var monster = new Enemy(Record.enemy, lvl);
        monster.Create();
        return monster;
    }
}

[System.Serializable]
public class EnemyEncounterRecord
{
    public EnemyTemplate enemy;
    public Vector2Int levelRange;
    public int chancepcnt;

    public int lwrchance { get; set; }
    public int upprchance { get; set; }
}

