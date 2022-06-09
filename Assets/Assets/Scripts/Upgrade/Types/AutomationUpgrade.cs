
namespace Idle
{
    public class AutomationUpgrade : Upgrade 
    {
        //Base method is responsible for the purchase of the upgrade
        public override void UpgradeItem(int id)
        {
            base.UpgradeItem(id);
            if (!priced)
                return;

            /////////////////////////////////////////////// #Start
            //This is where the logic of the action is written, provided that we have purchased

            DataManager.data.MoneyPerSecond += Items[id].value; //Adds Value to Money Per Second

            /////////////////////////////////////////////// #End

            Upgraded(); //The method is responsible for the successful purchase, makes saving

        }


    }
}