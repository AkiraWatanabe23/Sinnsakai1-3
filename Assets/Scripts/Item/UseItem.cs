using Consts;
using UnityEngine;

namespace Item
{
    public static class UseItem
    {
        //アイテム使うときにエフェクトとかあったら分かりやすいかも?
        public static void StealthItem(GameObject go)
        {
            //↓Playerをステルス状態にする
            go.tag = Define.STEALTH_TAG;
            //↓視覚的なステルス状態(透明度を半分まで落とす)
            float alpha = 1f;
            Color color = go.GetComponent<MeshRenderer>().material.color;
            alpha /= 2f;

            color.a = alpha;
            go.GetComponent<MeshRenderer>().material.color = color;
        }

        public static void HealItem(GameObject go)
        {
            int healValue = Random.Range(5, 16);
            var health = go.GetComponent<PlayerController>().Health;
            //↓Playerの体力を回復する
            health.HP += healValue;

            if (health.HP >= health.MaxHp)
            {
                health.HP = health.MaxHp;
            }
            Debug.Log($"Playerの体力を {healValue} 回復しました。");
        }

        public static void StatusUpItem(GameObject go, int item)
        {
            int riseValue = Random.Range(5, 11);

            //どのステータスがUPするかはランダムで決まります
            switch (item)
            {
                case 1:
                    //TODO：Playerの移動速度up
                    var speed = go.GetComponent<PlayerController>().Movements;
                    speed.MoveSpeed += riseValue;
                    break;
                case 2:
                    //TODO：Playerのジャンプ力up
                    var jump = go.GetComponent<PlayerController>().Movements;
                    jump.JumpPower += riseValue;
                    break;
                case 3:
                    //TODO：PlayerのHP上限up -> UIに反映
                    var health = go.GetComponent<PlayerController>().Health;
                    break;
                case 4:
                    //ハズレ?(ex.制限時間down)
                    break;
            }
        }
    }
}
