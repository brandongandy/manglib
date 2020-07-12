﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Mang.Data.Names
{
  public static class Egypt
  {
    public static readonly List<string> Female = new List<string>()
    {
      "Abana",
      "Adjedaa",
      "Ahwere",
      "Amenirdis",
      "Amenkhenwast",
      "Amosis",
      "Anhay",
      "Ankhesenamun",
      "Ankhesenaten",
      "Ankhesenneferibre",
      "Ankhetperure",
      "Ankhnesmeryre",
      "Ankhnesneferibre",
      "Asenath",
      "Baktre",
      "Baktwerel",
      "Beketaten",
      "Bithiah",
      "Duathor",
      "Esemkhebe",
      "Hehenhit",
      "Hentempet",
      "Henttimehu",
      "Henut",
      "Henutmire",
      "Hetepheres",
      "Hrere",
      "Huy",
      "In",
      "Inhapi",
      "Inihue",
      "Ipip",
      "Ipu",
      "Ipuky",
      "Ipy",
      "Iras",
      "Isetemkheb",
      "Isetnefret",
      "Isiemkheb",
      "Iuhetibu",
      "Karpes",
      "Kawit",
      "Kem",
      "Khedebneithireretbeneret",
      "Khutenptah",
      "Maatneferure",
      "Maetkare",
      "Maharet",
      "Makare",
      "Mayati",
      "Mehetweshkhet",
      "Mehtetweshket",
      "Mehytenweskhet",
      "Meketaten",
      "Meketre",
      "Mekhare",
      "Meresankh",
      "Meritaten",
      "Meryetamun",
      "Meryetaten",
      "Meryetre",
      "Meryt",
      "Mutemhab",
      "Naneferher",
      "Nany",
      "Naunakhte",
      "Nebefer",
      "Nebnofret",
      "Neferet",
      "Neferhetetepes",
      "Neferneferuaten",
      "Neferneferure",
      "Nefertiry",
      "Neferu",
      "Neferubity",
      "Neferuptah",
      "Neferure",
      "Neferusherit",
      "Neskhons",
      "Nestanebtishru",
      "Nitetis",
      "Nitiqret",
      "Niutnakht",
      "Nodjmet",
      "Nofretiri",
      "Nofritari",
      "Nofrure",
      "Nubkhaes",
      "Nubkhas",
      "Nyla",
      "Rai",
      "Reddjedet",
      "Reonet",
      "Roy",
      "Ruia",
      "Satdjehuty",
      "Satnebetneninesu",
      "Sebtitis",
      "Senebtisi",
      "Senebtysy",
      "Senet",
      "Senmonthis",
      "Sennuwy",
      "Sentnay",
      "Shesh",
      "Sit-Hathor-Iunet",
      "Sitkamose",
      "Sitre",
      "Sobekemshaf",
      "Sotepenre",
      "Sponnesis",
      "Tabes",
      "Tabesheribet",
      "Tabubu",
      "Taheret",
      "Tahpenes",
      "Tairetdjeret",
      "Tais",
      "Taiuhery",
      "Takhat",
      "Tamin",
      "Tanetnephthys",
      "Taweret",
      "Tayuheret",
      "Tetisherit",
      "Tiaa",
      "Timat",
      "Tjia",
      "Tjuiu",
      "Tjuyu",
      "Tutu",
      "Wenis",
      "Weret",
      "Wernero"
    };

    public static readonly List<string> Male = new List<string>()
    {
      "Aakheperkare",
      "Addaya",
      "Ahhotpe",
      "Ahmes",
      "Ahmose",
      "Ahmose-saneit",
      "Ahmose-sipari",
      "Akencheres",
      "Akunosh",
      "Amenakht",
      "Amenakhte",
      "Amenemhat",
      "Amenemheb",
      "Amenemopet",
      "Amenhirkopshef",
      "Amenhirwenemef",
      "Amenhotpe",
      "Amenmesse",
      "Amenmose",
      "Amennestawy",
      "Amenope",
      "Amenophis",
      "Amenwahsu",
      "Ameny",
      "Amosis-ankh",
      "Amoy",
      "Amunemhat",
      "Amunherpanesha",
      "Amunhotpe",
      "Anen",
      "Ankhef",
      "Ankhefenamun",
      "Ankhefenkhons",
      "Ankhefenmut",
      "Ankh-Psamtek",
      "Ankhsheshonq",
      "Ankhtify",
      "Ankhtyfy",
      "Ankhu",
      "Ankhuemhesut",
      "Any",
      "Apophis",
      "Baba",
      "Baenre",
      "Bak",
      "Bakenkhons",
      "Bakenkhonsu",
      "Bakenmut",
      "Bakennefi",
      "Bakenptah",
      "Baky",
      "Bata",
      "Bay",
      "Bek",
      "Bengay",
      "Besenmut",
      "Butehamun",
      "Denger",
      "Deniuenkhons",
      "Djadjaemankh",
      "Djau",
      "Djedefhor",
      "Djedhor",
      "Djedhoriufankh",
      "Djedi",
      "Djedkhonsiufankh",
      "Djedkhonsuefankh",
      "Djedptahefankh",
      "Djedptahiufankh",
      "Djehutmose",
      "Djehuty",
      "Djehutymose",
      "Djenutymes",
      "Djeserka",
      "Djeserkare",
      "Djeserkheprure",
      "Djesersukhons",
      "Djethutmose",
      "Djhutmose",
      "Genubath",
      "Gua",
      "Haankhef",
      "Hapimen",
      "Hapu",
      "Hapuseneb",
      "Hapymen",
      "Haremakhet",
      "Haremsat",
      "Harkhebi",
      "Harkhuf",
      "Harmhabi",
      "Harnakhte",
      "Harsiese",
      "Hay",
      "Hemaka",
      "Henenu",
      "Henuka",
      "Heqaemeheh",
      "Heqaib",
      "Herenamenpenaef",
      "Herihor",
      "Hesire",
      "Hor",
      "Horapollo",
      "Hordedef",
      "Horemheb",
      "Hori",
      "Hornedjitef",
      "Horpais",
      "Horwebbefer",
      "Hrihor",
      "Hunefer",
      "Huy",
      "Huya",
      "Iawy",
      "Ibana",
      "Ibe",
      "Idy",
      "Ikeni",
      "Ikui",
      "Imhotep",
      "Inarus",
      "Inebni",
      "Ineni",
      "Inyotef",
      "Ipi",
      "Ipuwer",
      "Ipuy",
      "Ipy",
      "Ishpi",
      "Iu-Amun",
      "Iufankh",
      "Iufenamun",
      "Iunmin",
      "Iuseneb",
      "Iuwlot",
      "Iyerniutef",
      "Iyimennuef",
      "Iymeru",
      "Jarha",
      "Kadjadja",
      "Kahma",
      "Kaka",
      "Kanakht",
      "Karnefhere",
      "Katenen",
      "Kawab",
      "Kay",
      "Kemuny",
      "Kenamun",
      "Kenefer",
      "Kerasher",
      "Kha",
      "Khaemhet",
      "Khaemnetjeru",
      "Khaemwaset",
      "Khahor",
      "Khakheperraseneb",
      "Kha'y",
      "Khensthoth",
      "Kheruef",
      "Khety",
      "Khnemibre",
      "Khnumhotep",
      "Khnumhotpe",
      "Khons",
      "Khonsirdais",
      "Khonskhu",
      "Khonsuemwaset",
      "Khufukhaf",
      "Khui",
      "Kuenre",
      "Kysen",
      "Maakha",
      "Mahu",
      "Mahuhy",
      "Maiherpri",
      "Ma'nakhtuf",
      "Manetho",
      "Masaharta",
      "May",
      "Maya",
      "Mehy",
      "Meketre",
      "Mekhu",
      "Men",
      "Menkheperraseneb",
      "Menkheperre",
      "Menmet-Ra",
      "Menna",
      "Mentuemhat",
      "Mentuherkhepshef",
      "Meremptor",
      "Merenamun",
      "Merenkhons",
      "Merenptah",
      "Mereruka",
      "Merka",
      "Mernebptah",
      "Mery",
      "Meryamun",
      "Meryatum",
      "Meryawy",
      "Merymose",
      "Meryptah",
      "Meryrahashtef",
      "Meryre",
      "Mes",
      "Min",
      "Minkhat",
      "Minmose",
      "Minnakht",
      "Mokhtar",
      "Montjuemhat",
      "Montjuhirkopshef",
      "Montuemhet",
      "Mose",
      "Naga-ed-der",
      "Nakhthorheb",
      "Nakhtimenwast",
      "Nakhtmin",
      "Nakhtnebef",
      "Naneferkeptah",
      "Nebamun",
      "Nebankh",
      "Nebemakst",
      "Nebhotep",
      "Nebimes",
      "Nebitka",
      "Nebmaetre",
      "Nebnefer",
      "Nebnetjeru",
      "Nebseni",
      "Nebseny",
      "Nebwennenef",
      "Nechoutes",
      "Neferhotep",
      "Neferhotpe",
      "Neferkheperuhersekheper",
      "Nefermaet",
      "Nefermenu",
      "Neferrenpet",
      "Neferti",
      "Nehasy",
      "Nehi",
      "Nekau",
      "Nekhwemmut",
      "Nendjbaendjed",
      "Nenedjebaendjed",
      "Neneferkaptah",
      "Nenkhefta",
      "Nes",
      "Nesamun",
      "Neshi",
      "Neshorpakhered",
      "Neskhons",
      "Nesmont",
      "Nespaherenhat",
      "Nespakashuty",
      "Nespatytawy",
      "Nespherenhat",
      "Nessuimenopet",
      "Nestanebetasheru",
      "Nestefnut",
      "Netihur",
      "Nigmed",
      "Nimlot",
      "Niumateped",
      "Pabasa",
      "Pabernefy",
      "Padiamenet",
      "Padiamenipet",
      "Padiamun",
      "Padineith",
      "Paheripedjet",
      "Pairy",
      "Pait",
      "Pakharu",
      "Pakhneter",
      "Pamont",
      "Pamose",
      "Pamu",
      "Panas",
      "Paneb",
      "Paneferher",
      "Panehesy",
      "Paperpa",
      "Paramesse",
      "Parennefer",
      "Pasebakhaenniut",
      "Pasekhonsu",
      "Paser",
      "Pashedbast",
      "Pashedu",
      "Pasherdjehuty",
      "Pa-Siamun",
      "Pawiaeadja",
      "Paynedjem",
      "Payneferher",
      "Pediamun",
      "Pediese",
      "Pedihor",
      "Penamun",
      "Penbuy",
      "Penmaat",
      "Pennestawy",
      "Pentaweret",
      "Pentu",
      "Pepynakhte",
      "Peraha",
      "Pinhasy",
      "Pinotmou",
      "Prahotpe",
      "Pramessu",
      "Preherwenemef",
      "Prehirwennef",
      "Prepayit",
      "Psamtek",
      "Psenamy",
      "Psenmin",
      "Ptahhemakhet",
      "Ptahhemhat-Ty",
      "Ptahhotep",
      "Ptahhudjankhef",
      "Ptahmose",
      "Ptahshepses",
      "Qenymin",
      "Rahotep",
      "Rahotpe",
      "Raia",
      "Ramessenakhte",
      "Ramessu",
      "Rekhmire",
      "Reuser",
      "Rewer",
      "Roma-Roy",
      "Rudamun",
      "Sabef",
      "Sabni",
      "Salatis",
      "Samut",
      "Sanehet",
      "Sasobek",
      "Sawesit",
      "Scepter",
      "Sekhemkare",
      "Sekhmire",
      "Seneb",
      "Senebtyfy",
      "Senemut",
      "Senmen",
      "Sennedjem",
      "Sennefer",
      "Sennufer",
      "Senui",
      "Senwosret",
      "Serapion",
      "Sese",
      "Setau",
      "Setep",
      "Sethe",
      "Sethherwenemef",
      "Sethhirkopshef",
      "Sethnakhte",
      "Sethnakte",
      "Sethy",
      "Setne",
      "Setymerenptah",
      "Shedsunefertum",
      "Shemay",
      "Shepenwepet",
      "Siamun",
      "Siese",
      "Si-Mut",
      "Sinuhe",
      "Sipair",
      "Sneferu",
      "Somtutefnakhte",
      "Surero",
      "Suty",
      "Sutymose",
      "Takairnayu",
      "Takany",
      "Tasetmerydjehuty",
      "Tayenimu",
      "Tefibi",
      "Tenermentu",
      "Teti-en",
      "Tetisheri",
      "Tjaenhebyu",
      "Tjahapimu",
      "Tjaroy",
      "Tjauemdi",
      "Tjenna",
      "Tjety",
      "To",
      "Tui",
      "Tutu",
      "Tymisba",
      "Udjahorresne",
      "Udjahorresneith",
      "Uni",
      "Userhet",
      "Usermontju",
      "Wadjmose",
      "Wahibre-Teni",
      "Wahka",
      "Webaoner",
      "Webensenu",
      "Wedjakhons",
      "Wenamun",
      "Wendjabaendjed",
      "Wendjebaendjed",
      "Weni",
      "Wennefer",
      "Wennufer",
      "Wepmose",
      "Wepwawetmose",
      "Werdiamenniut",
      "Werirenptah",
      "Yanhamu",
      "Yey",
      "Yii",
      "Yuya",
      "Zazamoukh"
    };
  }
}