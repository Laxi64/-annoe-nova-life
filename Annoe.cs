using Life;
using UnityEngine;
using Life.Network;
using Life.UI;



namespace annoeall
{
    public class annoeall : Plugin
    {

        public annoeall(IGameAPI api) : base(api)
        {

        }

        public override void OnPluginInit()
        {
            new SChatCommand("/annoeall", "Pour afficher le tuto", "/annoeall", (player, arg) =>
            {
                annoe(player);
            }).Register();
            new SChatCommand("/notifall", "Pour afficher le tuto", "/notifall", (player, arg) =>
            {
                notifall(player);
            }).Register();
            Debug.Log("Annoeall fonctionne correctement");

        }

        public void notifall(Player player)
        {
            UIPanel panel = new UIPanel("ANNONCE!", UIPanel.PanelType.Input);
            UIPanel panels = new UIPanel("Temps", UIPanel.PanelType.Input);
            panels.AddButton("<color=#fc0303>FERMER</color>", delegate
            {
                    
                player.ClosePanel(panels);
               
            });
            panel.AddButton("<color=#fc0303>FERMER</color>", delegate
            {
                    
                player.ClosePanel(panel);
               
            });
            panels.AddButton("<color=#00FF00>Envoyer</color>", delegate
            {
                string time = panels.inputText;
                float temps = float.Parse(time, System.Globalization.CultureInfo.InvariantCulture);
                string content = panel.inputText;
                if (player.IsAdmin)
                {
                    
                    foreach (Player players in Nova.server.Players)
                    {
                        players.Notify("ANNONCE", $"{content}", NotificationManager.Type.Warning, temps);
                    }
                }
                else
                {
                    player.Notify("ERREUR","Vous n'avez pas les droits administrateurs suffisant pour effectuer cette commande", NotificationManager.Type.Error);
                }
            });
            panel.AddButton("<color=#00FF00>Suivant</color>", delegate
            { 
                player.ClosePanel(panel);
                player.ShowPanelUI(panels);
            });
            player.ShowPanelUI(panel);
        }

        public void annoe(Player player)
        {
            UIPanel panels = new UIPanel("Temps", UIPanel.PanelType.Input);
            UIPanel panel = new UIPanel("ANNONCE!", UIPanel.PanelType.Input);
            panel.AddButton("<color=#fc0303>FERMER</color>", delegate
            {
                    
                player.ClosePanel(panel);
               
            });
            panels.AddButton("<color=#fc0303>FERMER</color>", delegate
            {
                    
                player.ClosePanel(panels);
               
            });
            panel.AddButton("<color=#00FF00>Suivant</color>", delegate
            {
                player.ClosePanel(panel);
                player.ShowPanelUI(panels); 
            });
            panels.AddButton("<color=#00FF00>Envoyer</color>", delegate
            {
                string time = panels.inputText;
                float temps = float.Parse(time, System.Globalization.CultureInfo.InvariantCulture);
                string content = panel.inputText;
                if (player.IsAdmin)
                {
                    
                    foreach (Player players in Nova.server.Players)
                    {
                        players.setup.TargetShowCenterText("ANNONCE",$"{content}", temps);
                    }
                }
                else
                {
                    player.Notify("ERREUR","Vous n'avez pas les droits administrateurs suffisant pour effectuer cette commande", NotificationManager.Type.Error);
                }
            });
            player.ShowPanelUI(panel);
           
        }
    }
}
