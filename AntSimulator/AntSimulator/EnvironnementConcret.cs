using System;
using System.Reflection;
using AntSimulator.Fabrique;
using AntSimulator.Personnage;

namespace AntSimulator
{
    public class EnvironnementConcret : EnvironnementAbstrait
    {

        private static EnvironnementConcret instance = null;

        public static EnvironnementConcret getInstance()
        {
            if (instance == null)
                return new EnvironnementConcret();
            return EnvironnementConcret.instance;
        }
        public EnvironnementConcret(): base()
        {
            InitZones();
            InitChemins();
            
        }
        public void InitZones()
        {
            for (int i = 0; i < FourmiliereConstante.NbCase; i++)
            {
                for (int j = 0; j < FourmiliereConstante.NbCase; j++)
                {
                    this.ZoneAbstraiteList[i].zoneAbstraiteList[j]=new BoutDeTerrain("", new Coordonnees(i, j));
                }
            }
        }
        public override void InitChemins()
        {
            for (int i = 0; i < FourmiliereConstante.NbCase; i++)
            {
                for (int j = 0; j < FourmiliereConstante.NbCase; j++)
                {
                    for (int k = i - 1; k <= i; k++)
                    {
                        for (int l = j - 1; l <= j; l++)
                        {
                            if (k >= 1)
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.gauche] = new PaireDirection((int)FourmiliereConstante.direction.gauche, new Chemin(new Coordonnees(i, j), new Coordonnees(i - 1, j)));
                            else
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.gauche] = null;
                            if (k < FourmiliereConstante.NbCase - 1)
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.droite] = new PaireDirection((int)FourmiliereConstante.direction.droite, new Chemin(new Coordonnees(i, j), new Coordonnees(i + 1, j)));
                            else
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.droite] = null;
                            if (l >= 1)
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.bas] = new PaireDirection((int)FourmiliereConstante.direction.bas, new Chemin(new Coordonnees(i, j), new Coordonnees(i, j - 1)));
                            else
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.bas] = null;
                            if (l < FourmiliereConstante.NbCase - 1)
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.haut] = new PaireDirection((int)FourmiliereConstante.direction.haut, new Chemin(new Coordonnees(i, j), new Coordonnees(i, j + 1)));
                            else
                                ZoneAbstraiteList[i].zoneAbstraiteList[j].AccesAbstraitList[(int)FourmiliereConstante.direction.haut] = null;
                        }
                    }
                }
            }
            
        }
        public override void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {
            throw new NotImplementedException();
        }

        public override void ChargerEnvironnement(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void ChargerObjets(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            throw new NotImplementedException();
        }

        public override void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite source, ZoneAbstraite destination)
        {
            throw new NotImplementedException();
        }

        public override string Simuler()
        {
            throw new NotImplementedException();
        }

        public override string Statistiques()
        {
            throw new NotImplementedException();
        }
    }
}
