using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class TemplateMethodPatternExercise : MonoBehaviour
    {
        private void Start()
        {
            GameAI orc = new OrcsAI();
            orc.turn();

            GameAI monster = new MonstersAI();
            monster.turn();
        }

        public abstract class GameAI
        {
            public void turn()
            {
                Debug.Log("Turn");
                collectResource();
                buildStructures();
                buildUnits();
                attack();
            }

            private void takeTurn()
            {
                Debug.Log("Take Turn");
            }

            private void collectResource()
            {
                Debug.Log("Collect Resource");
            }

            protected abstract void buildStructures();

            protected abstract void buildUnits();

            private void attack()
            {
                Debug.Log("Attack");

                if (Random.Range(0, 2) == 0)
                    sendScouts(Vector3.zero);
                else
                    sendWarriors(Vector3.zero);
            }

            protected abstract void sendScouts(Vector3 position);
            protected abstract void sendWarriors(Vector3 position);
        }

        public class OrcsAI : GameAI
        {
            protected override void buildStructures()
            {
                Debug.Log("Orcs Build Structures");
            }

            protected override void buildUnits()
            {
                Debug.Log("Orcs Build Units");
            }

            protected override void sendScouts(Vector3 position)
            {
                Debug.Log("Orcs Send Scouts");
            }

            protected override void sendWarriors(Vector3 position)
            {
                Debug.Log("Orcs Send Warriors");
            }
        }

        public class MonstersAI : GameAI
        {
            protected override void buildStructures()
            {
                Debug.Log("Monsters Build Structures");
            }

            protected override void buildUnits()
            {
                Debug.Log("Monsters Build Units");
            }

            protected override void sendScouts(Vector3 position)
            {

            }

            protected override void sendWarriors(Vector3 position)
            {

            }
        }
    }
}