using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RessourcesRelationnellesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie_Ressources",
                columns: table => new
                {
                    id_categorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_categorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie_Ressources", x => x.id_categorie);
                });

            migrationBuilder.CreateTable(
                name: "Langues",
                columns: table => new
                {
                    id_langue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langues", x => x.id_langue);
                });

            migrationBuilder.CreateTable(
                name: "Type_Relations",
                columns: table => new
                {
                    id_Type_Relation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Relations", x => x.id_Type_Relation);
                });

            migrationBuilder.CreateTable(
                name: "Type_Utilisateurs",
                columns: table => new
                {
                    id_type_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Utilisateurs", x => x.id_type_user);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    id_ressource = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    langueid_langue = table.Column<int>(type: "int", nullable: false),
                    date_moderation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validation_moderation = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age_minimum = table.Column<int>(type: "int", nullable: false),
                    compteur_vues = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_taille = table.Column<float>(type: "real", nullable: true),
                    taille = table.Column<float>(type: "real", nullable: true),
                    Texte_taille = table.Column<float>(type: "real", nullable: true),
                    Video_taille = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.id_ressource);
                    table.ForeignKey(
                        name: "FK_Ressources_Langues_langueid_langue",
                        column: x => x.langueid_langue,
                        principalTable: "Langues",
                        principalColumn: "id_langue",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mdp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_naissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom_jeune_fille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    langueid_langue = table.Column<int>(type: "int", nullable: false),
                    derniere_date_connexion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validation_rgpd = table.Column<bool>(type: "bit", nullable: false),
                    date_validation_rgpd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    accord_confidentialite = table.Column<bool>(type: "bit", nullable: false),
                    date_accord_confidentialite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numero_telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Utilisateurid_type_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Langues_langueid_langue",
                        column: x => x.langueid_langue,
                        principalTable: "Langues",
                        principalColumn: "id_langue",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Type_Utilisateurs_Type_Utilisateurid_type_user",
                        column: x => x.Type_Utilisateurid_type_user,
                        principalTable: "Type_Utilisateurs",
                        principalColumn: "id_type_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trier_Ressources_Categories",
                columns: table => new
                {
                    id_trier_categories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorie_Ressourceid_categorie = table.Column<int>(type: "int", nullable: false),
                    Ressourcesid_ressource = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trier_Ressources_Categories", x => x.id_trier_categories);
                    table.ForeignKey(
                        name: "FK_Trier_Ressources_Categories_Categorie_Ressources_Categorie_Ressourceid_categorie",
                        column: x => x.Categorie_Ressourceid_categorie,
                        principalTable: "Categorie_Ressources",
                        principalColumn: "id_categorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trier_Ressources_Categories_Ressources_Ressourcesid_ressource",
                        column: x => x.Ressourcesid_ressource,
                        principalTable: "Ressources",
                        principalColumn: "id_ressource",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    id_chat = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jeuid_ressource = table.Column<long>(type: "bigint", nullable: false),
                    utilisateurid_user = table.Column<long>(type: "bigint", nullable: false),
                    date_chat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message_chat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.id_chat);
                    table.ForeignKey(
                        name: "FK_Chats_Ressources_jeuid_ressource",
                        column: x => x.jeuid_ressource,
                        principalTable: "Ressources",
                        principalColumn: "id_ressource",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Utilisateurs_utilisateurid_user",
                        column: x => x.utilisateurid_user,
                        principalTable: "Utilisateurs",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    id_Commentaire = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_commentaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    utilisateurid_user = table.Column<long>(type: "bigint", nullable: false),
                    ressourcesid_ressource = table.Column<long>(type: "bigint", nullable: false),
                    commentaire_parentid_Commentaire = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.id_Commentaire);
                    table.ForeignKey(
                        name: "FK_Commentaires_Commentaires_commentaire_parentid_Commentaire",
                        column: x => x.commentaire_parentid_Commentaire,
                        principalTable: "Commentaires",
                        principalColumn: "id_Commentaire",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Commentaires_Ressources_ressourcesid_ressource",
                        column: x => x.ressourcesid_ressource,
                        principalTable: "Ressources",
                        principalColumn: "id_ressource",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Commentaires_Utilisateurs_utilisateurid_user",
                        column: x => x.utilisateurid_user,
                        principalTable: "Utilisateurs",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Partager",
                columns: table => new
                {
                    id_Partager = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utilisateurid_user = table.Column<long>(type: "bigint", nullable: false),
                    ressourcesid_ressource = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partager", x => x.id_Partager);
                    table.ForeignKey(
                        name: "FK_Partager_Ressources_ressourcesid_ressource",
                        column: x => x.ressourcesid_ressource,
                        principalTable: "Ressources",
                        principalColumn: "id_ressource",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Partager_Utilisateurs_Utilisateurid_user",
                        column: x => x.Utilisateurid_user,
                        principalTable: "Utilisateurs",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Relation_Utilisateurs",
                columns: table => new
                {
                    id_Relation_Utilisateurs = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    utilisateurid_user = table.Column<long>(type: "bigint", nullable: false),
                    utilisateur_vouluid_user = table.Column<long>(type: "bigint", nullable: false),
                    Type_Relationid_Type_Relation = table.Column<int>(type: "int", nullable: false),
                    relation_Confirmee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation_Utilisateurs", x => x.id_Relation_Utilisateurs);
                    table.ForeignKey(
                        name: "FK_Relation_Utilisateurs_Type_Relations_Type_Relationid_Type_Relation",
                        column: x => x.Type_Relationid_Type_Relation,
                        principalTable: "Type_Relations",
                        principalColumn: "id_Type_Relation",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Relation_Utilisateurs_Utilisateurs_utilisateur_vouluid_user",
                        column: x => x.utilisateur_vouluid_user,
                        principalTable: "Utilisateurs",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Relation_Utilisateurs_Utilisateurs_utilisateurid_user",
                        column: x => x.utilisateurid_user,
                        principalTable: "Utilisateurs",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_jeuid_ressource",
                table: "Chats",
                column: "jeuid_ressource");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_utilisateurid_user",
                table: "Chats",
                column: "utilisateurid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_commentaire_parentid_Commentaire",
                table: "Commentaires",
                column: "commentaire_parentid_Commentaire");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ressourcesid_ressource",
                table: "Commentaires",
                column: "ressourcesid_ressource");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_utilisateurid_user",
                table: "Commentaires",
                column: "utilisateurid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Partager_ressourcesid_ressource",
                table: "Partager",
                column: "ressourcesid_ressource");

            migrationBuilder.CreateIndex(
                name: "IX_Partager_Utilisateurid_user",
                table: "Partager",
                column: "Utilisateurid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_Utilisateurs_Type_Relationid_Type_Relation",
                table: "Relation_Utilisateurs",
                column: "Type_Relationid_Type_Relation");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_Utilisateurs_utilisateur_vouluid_user",
                table: "Relation_Utilisateurs",
                column: "utilisateur_vouluid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_Utilisateurs_utilisateurid_user",
                table: "Relation_Utilisateurs",
                column: "utilisateurid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_langueid_langue",
                table: "Ressources",
                column: "langueid_langue");

            migrationBuilder.CreateIndex(
                name: "IX_Trier_Ressources_Categories_Categorie_Ressourceid_categorie",
                table: "Trier_Ressources_Categories",
                column: "Categorie_Ressourceid_categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Trier_Ressources_Categories_Ressourcesid_ressource",
                table: "Trier_Ressources_Categories",
                column: "Ressourcesid_ressource");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_langueid_langue",
                table: "Utilisateurs",
                column: "langueid_langue");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Type_Utilisateurid_type_user",
                table: "Utilisateurs",
                column: "Type_Utilisateurid_type_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Partager");

            migrationBuilder.DropTable(
                name: "Relation_Utilisateurs");

            migrationBuilder.DropTable(
                name: "Trier_Ressources_Categories");

            migrationBuilder.DropTable(
                name: "Type_Relations");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Categorie_Ressources");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "Type_Utilisateurs");

            migrationBuilder.DropTable(
                name: "Langues");
        }
    }
}
