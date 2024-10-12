public class TreasureQuotaTask{
    public int treasureQuota;
    public int treasureCollected;

    public void collectTreasure(Treasure treasure, Player player){
        //add treasure to inventory
        treasure.setCollected(true, player);
        //update completedness (treasureCollected/treasureQuota)
    }
}