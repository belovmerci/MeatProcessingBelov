using System;
using System.Collections.Generic;
using MeatProcessingBelov.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeatProcessingBelov.Models;

public partial class BelovMeat2207sb1Context : DbContext
{
    public BelovMeat2207sb1Context(DbContextOptions<BelovMeat2207sb1Context> options)
        : base(options)
    {
    }

    // public BelovMeat2207sb1Context(string connectionString) : base(connectionString) {}

    /*
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    */


    public virtual DbSet<Ассортименты> Ассортиментыs { get; set; }

    public virtual DbSet<Животные> Животныеs { get; set; }

    public virtual DbSet<ЖивотныеПоЗабоям> ЖивотныеПоЗабоямs { get; set; }

    public virtual DbSet<ЖурналОпераций> ЖурналОперацийs { get; set; }

    public virtual DbSet<Забои> Забоиs { get; set; }

    public virtual DbSet<Загоны> Загоныs { get; set; }

    public virtual DbSet<Корма> Кормаs { get; set; }

    public virtual DbSet<Магазины> Магазиныs { get; set; }

    public virtual DbSet<Мясо> Мясоs { get; set; }

    public virtual DbSet<Оборудование> Оборудованиеs { get; set; }

    public virtual DbSet<ОборудованиеПоРецептурам> ОборудованиеПоРецептурамs { get; set; }

    public virtual DbSet<ПартииМясныхПродуктов> ПартииМясныхПродуктовs { get; set; }

    public virtual DbSet<ПартииПоМагазинам> ПартииПоМагазинамs { get; set; }

    public virtual DbSet<Продажи> Продажиs { get; set; }

    public virtual DbSet<Работники> Работникиs { get; set; }

    public virtual DbSet<РаботникиМагазинов> РаботникиМагазиновs { get; set; }

    public virtual DbSet<РаботникиПоТипам> РаботникиПоТипамs { get; set; }

    public virtual DbSet<Рефрижераторы> Рефрижераторыs { get; set; }

    public virtual DbSet<Рецептуры> Рецептурыs { get; set; }

    public virtual DbSet<Склады> Складыs { get; set; }

    public virtual DbSet<Смены> Сменыs { get; set; }

    public virtual DbSet<ТипыЖивотных> ТипыЖивотныхs { get; set; }

    public virtual DbSet<ТипыКорма> ТипыКормаs { get; set; }

    public virtual DbSet<ТипыМяса> ТипыМясаs { get; set; }

    public virtual DbSet<ТипыМясаПоРецептурам> ТипыМясаПоРецептурамs { get; set; }

    public virtual DbSet<ТипыРаботников> ТипыРаботниковs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Belov_MEAT_2207sb1;Trusted_Connection=True;TrustServerCertificate=True;");

    /* for when the rest of the application parts are ready
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Belov_MEAT_2207sb1;User Id=myUsername;Password=myPassword;TrustServerCertificate=True;");
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ассортименты>(entity =>
        {
            entity.HasKey(e => e.АссортиментId).HasName("PK__Ассортим__56A034A217B1781D");

            entity.ToTable("Ассортименты");

            entity.Property(e => e.АссортиментId)
                .ValueGeneratedNever()
                .HasColumnName("АссортиментID");
            entity.Property(e => e.МагазинFk).HasColumnName("МагазинFK");
            entity.Property(e => e.РецептураFk).HasColumnName("РецептураFK");
        });

        modelBuilder.Entity<Животные>(entity =>
        {
            entity.HasKey(e => e.ЖивотноеId).HasName("PK__Животные__435F46AD8ABF3339");

            entity.ToTable("Животные");

            entity.Property(e => e.ЖивотноеId)
                .ValueGeneratedNever()
                .HasColumnName("ЖивотноеID");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата_рождения");
            entity.Property(e => e.ЗагонFk).HasColumnName("ЗагонFK");
            entity.Property(e => e.Кличка).HasMaxLength(50);
            entity.Property(e => e.Пол).HasMaxLength(50);
            entity.Property(e => e.ТипЖивотногоFk).HasColumnName("Тип_животногоFK");

        });

        modelBuilder.Entity<ЖивотныеПоЗабоям>(entity =>
        {
            entity.HasKey(e => e.ЖпзId).HasName("PK__Животные__31AF6E197325FD7A");

            entity.ToTable("Животные_по_забоям");

            entity.Property(e => e.ЖпзId)
                .ValueGeneratedNever()
                .HasColumnName("ЖПЗ_ID");
            entity.Property(e => e.ЖивотноеFk).HasColumnName("ЖивотноеFK");
            entity.Property(e => e.ЗабойFk).HasColumnName("ЗабойFK");
            entity.Property(e => e.Название).HasMaxLength(50);

        });

        modelBuilder.Entity<ЖурналОпераций>(entity =>
        {
            entity.HasKey(e => e.ЖоId).HasName("PK__Журнал_о__DBFD6E3CD8F6DDC9");

            entity.ToTable("Журнал_операций");

            entity.Property(e => e.ЖоId)
                .ValueGeneratedNever()
                .HasColumnName("ЖО_ID");
            entity.Property(e => e.ВремяПроведения).HasColumnName("Время_проведения");
            entity.Property(e => e.ЖивотноеFk).HasColumnName("ЖивотноеFK");
            entity.Property(e => e.КормFk).HasColumnName("КормFK");
            entity.Property(e => e.ОборудованиеFk).HasColumnName("ОборудованиеFK");
            entity.Property(e => e.СменаFk).HasColumnName("СменаFK");

        });

        modelBuilder.Entity<Забои>(entity =>
        {
            entity.HasKey(e => e.ЗабойId).HasName("PK__Забои__E06FF05EC20B8294");

            entity.ToTable("Забои");

            entity.Property(e => e.ЗабойId)
                .ValueGeneratedNever()
                .HasColumnName("ЗабойID");
            entity.Property(e => e.СменаFk).HasColumnName("СменаFK");

        });

        modelBuilder.Entity<Загоны>(entity =>
        {
            entity.HasKey(e => e.ЗагонId).HasName("PK__Загоны__D33BA360DEAF7111");

            entity.ToTable("Загоны");

            entity.Property(e => e.ЗагонId)
                .ValueGeneratedNever()
                .HasColumnName("ЗагонID");
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Описание).HasMaxLength(150);
        });

        modelBuilder.Entity<Корма>(entity =>
        {
            entity.HasKey(e => e.КормId).HasName("PK__Корма__70C10832B06332E4");

            entity.ToTable("Корма");

            entity.Property(e => e.КормId)
                .ValueGeneratedNever()
                .HasColumnName("КормID");
            entity.Property(e => e.КоличествоКг)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Количество_КГ");
            entity.Property(e => e.Описание).HasMaxLength(100);
            entity.Property(e => e.СкладFk).HasColumnName("СкладFK");
            entity.Property(e => e.ТипКормаFk).HasColumnName("Тип_кормаFK");


        });

        modelBuilder.Entity<Магазины>(entity =>
        {
            entity.HasKey(e => e.МагазинId).HasName("PK__Магазины__ED2ED3A0B7DD9DD2");

            entity.ToTable("Магазины");

            entity.Property(e => e.МагазинId)
                .ValueGeneratedNever()
                .HasColumnName("МагазинID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Адрес).HasMaxLength(50);
            entity.Property(e => e.Активный).HasDefaultValue(true);
            entity.Property(e => e.Город).HasMaxLength(50);
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Телефон).HasMaxLength(20);
        });

        modelBuilder.Entity<Мясо>(entity =>
        {
            entity.HasKey(e => e.МясоId).HasName("PK__Мясо__098E18A311B537B3");

            entity.ToTable("Мясо");

            entity.Property(e => e.МясоId)
                .ValueGeneratedNever()
                .HasColumnName("МясоID");
            entity.Property(e => e.ДатаВыработки)
                .HasColumnType("datetime")
                .HasColumnName("Дата_выработки");
            entity.Property(e => e.ЗабойFk).HasColumnName("ЗабойFK");
            entity.Property(e => e.КгМяса)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Кг_мяса");
            entity.Property(e => e.РефрижераторFk).HasColumnName("РефрижераторFK");
            entity.Property(e => e.ТипМясаFk).HasColumnName("Тип_мясаFK");

        });

        modelBuilder.Entity<Оборудование>(entity =>
        {
            entity.HasKey(e => e.ОборудованиеId).HasName("PK__Оборудов__307887790B7F6664");

            entity.ToTable("Оборудование");

            entity.Property(e => e.ОборудованиеId)
                .ValueGeneratedNever()
                .HasColumnName("ОборудованиеID");
            entity.Property(e => e.Активный).HasDefaultValue(true);
            entity.Property(e => e.ГодПроизводства).HasColumnName("Год_производства");
            entity.Property(e => e.Модель).HasMaxLength(50);
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<ОборудованиеПоРецептурам>(entity =>
        {
            entity.HasKey(e => e.ОпрId).HasName("PK__Оборудов__2E428BFD9EF9A503");

            entity.ToTable("Оборудование_по_рецептурам");

            entity.Property(e => e.ОпрId)
                .ValueGeneratedNever()
                .HasColumnName("ОПР_ID");
            entity.Property(e => e.ОборудованиеFk).HasColumnName("ОборудованиеFK");
            entity.Property(e => e.РецептураFk).HasColumnName("РецептураFK");

        });

        modelBuilder.Entity<ПартииМясныхПродуктов>(entity =>
        {
            entity.HasKey(e => e.ПмпId).HasName("PK__Партии_м__D07842C1C17C9356");

            entity.ToTable("Партии_мясных_продуктов");

            entity.Property(e => e.ПмпId)
                .ValueGeneratedNever()
                .HasColumnName("ПМП_ID");
            entity.Property(e => e.ДатаПроизводства)
                .HasColumnType("datetime")
                .HasColumnName("Дата_производства");
            entity.Property(e => e.РецептураFk).HasColumnName("РецептураFK");

        });

        modelBuilder.Entity<ПартииПоМагазинам>(entity =>
        {
            entity.HasKey(e => e.ПпмId).HasName("PK__Партии_п__6FAAEE83D204CE2E");

            entity.ToTable("Партии_по_магазинам");

            entity.Property(e => e.ПпмId)
                .ValueGeneratedNever()
                .HasColumnName("ППМ_ID");
            entity.Property(e => e.ДатаОтправки)
                .HasColumnType("datetime")
                .HasColumnName("Дата_отправки");
            entity.Property(e => e.ДатаПолучения)
                .HasColumnType("datetime")
                .HasColumnName("Дата_получения");
            entity.Property(e => e.МагазинFk).HasColumnName("МагазинFK");
            entity.Property(e => e.ПартияFk).HasColumnName("ПартияFK");

        });

        modelBuilder.Entity<Продажи>(entity =>
        {
            entity.HasKey(e => e.ПродажаId).HasName("PK__Продажи__80768A318240D681");

            entity.ToTable("Продажи");

            entity.Property(e => e.ПродажаId)
                .ValueGeneratedNever()
                .HasColumnName("ПродажаID");
            entity.Property(e => e.АссортиментFk).HasColumnName("АссортиментFK");
            entity.Property(e => e.МагазинFk).HasColumnName("МагазинFK");

        });

        modelBuilder.Entity<Работники>(entity =>
        {
            entity.HasKey(e => e.РаботникId).HasName("PK__Работник__58AD7082B9386266");

            entity.ToTable("Работники");

            entity.Property(e => e.РаботникId)
                .ValueGeneratedNever()
                .HasColumnName("РаботникID");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата_рождения");
            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Отчество).HasMaxLength(100);
            entity.Property(e => e.Пол).HasMaxLength(50);
            entity.Property(e => e.СерияНомерПаспорта)
                .HasMaxLength(50)
                .HasColumnName("Серия_номер_паспорта");
            entity.Property(e => e.Фамилия).HasMaxLength(100);
        });

        modelBuilder.Entity<РаботникиМагазинов>(entity =>
        {
            entity.HasKey(e => e.РаботникМагазинаId).HasName("PK__Работник__47098CC9B927E6F5");

            entity.ToTable("Работники_магазинов");

            entity.Property(e => e.РаботникМагазинаId)
                .ValueGeneratedNever()
                .HasColumnName("РаботникМагазинаID");
            entity.Property(e => e.МагазинFk).HasColumnName("МагазинFK");
            entity.Property(e => e.РаботникFk).HasColumnName("РаботникFK");

        });

        modelBuilder.Entity<РаботникиПоТипам>(entity =>
        {
            entity.HasKey(e => e.РптId).HasName("PK__Работник__FFE44951156759E5");

            entity.ToTable("Работники_по_типам");

            entity.Property(e => e.РптId)
                .ValueGeneratedNever()
                .HasColumnName("РПТ_ID");
            entity.Property(e => e.РаботникFk).HasColumnName("РаботникFK");
            entity.Property(e => e.ТипРаботникаFk).HasColumnName("Тип_работникаFK");

        });

        modelBuilder.Entity<Рефрижераторы>(entity =>
        {
            entity.HasKey(e => e.РефрижераторId).HasName("PK__Рефрижер__84AD5EE8A5127FD0");

            entity.ToTable("Рефрижераторы");

            entity.Property(e => e.РефрижераторId)
                .ValueGeneratedNever()
                .HasColumnName("РефрижераторID");
            entity.Property(e => e.ВместимостьКг).HasColumnName("Вместимость_КГ");
            entity.Property(e => e.Модель).HasMaxLength(50);
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<Рецептуры>(entity =>
        {
            entity.HasKey(e => e.РецептураId).HasName("PK__Рецептур__9FABF363B4AA04AF");

            entity.ToTable("Рецептуры");

            entity.Property(e => e.РецептураId)
                .ValueGeneratedNever()
                .HasColumnName("РецептураID");
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Описание).HasMaxLength(350);
        });

        modelBuilder.Entity<Склады>(entity =>
        {
            entity.HasKey(e => e.СкладId).HasName("PK__Склады__D76E19D1057D87A3");

            entity.ToTable("Склады");

            entity.Property(e => e.СкладId)
                .ValueGeneratedNever()
                .HasColumnName("СкладID");
            entity.Property(e => e.Локация).HasMaxLength(100);
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<Смены>(entity =>
        {
            entity.HasKey(e => e.СменаId).HasName("PK__Смены__35F57382A275658D");

            entity.ToTable("Смены");

            entity.Property(e => e.СменаId)
                .ValueGeneratedNever()
                .HasColumnName("СменаID");
            entity.Property(e => e.Конец).HasColumnType("datetime");
            entity.Property(e => e.Начало).HasColumnType("datetime");
            entity.Property(e => e.РаботникFk).HasColumnName("РаботникFK");

        });

        modelBuilder.Entity<ТипыЖивотных>(entity =>
        {
            entity.HasKey(e => e.ТипЖивотногоId).HasName("PK__Типы_жив__3ACF95692CCAE485");

            entity.ToTable("Типы_животных");

            entity.Property(e => e.ТипЖивотногоId)
                .ValueGeneratedNever()
                .HasColumnName("Тип_животногоID");
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<ТипыКорма>(entity =>
        {
            entity.HasKey(e => e.ТипКормаId).HasName("PK__Типы_кор__C18269BC9034917B");

            entity.ToTable("Типы_корма");

            entity.Property(e => e.ТипКормаId)
                .ValueGeneratedNever()
                .HasColumnName("Тип_кормаID");
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<ТипыМяса>(entity =>
        {
            entity.HasKey(e => e.ТипМясаId).HasName("PK__Типы_мяс__75CCC65F6EE9CB33");

            entity.ToTable("Типы_мяса");

            entity.Property(e => e.ТипМясаId)
                .ValueGeneratedNever()
                .HasColumnName("Тип_мясаID");
            entity.Property(e => e.Название).HasMaxLength(50);
        });

        modelBuilder.Entity<ТипыМясаПоРецептурам>(entity =>
        {
            entity.HasKey(e => e.ТмпрId).HasName("PK__Типы_мяс__33D40D2D4945BDB9");

            entity.ToTable("Типы_мяса_по_рецептурам");

            entity.Property(e => e.ТмпрId)
                .ValueGeneratedNever()
                .HasColumnName("ТМПР_ID");
            entity.Property(e => e.РецептураFk).HasColumnName("РецептураFK");
            entity.Property(e => e.ТипМясаFk).HasColumnName("Тип_мясаFK");

        });

        modelBuilder.Entity<ТипыРаботников>(entity =>
        {
            entity.HasKey(e => e.ТрId).HasName("PK__Типы_раб__980B93E478FD8B35");

            entity.ToTable("Типы_работников");

            entity.Property(e => e.ТрId)
                .ValueGeneratedNever()
                .HasColumnName("ТР_ID");
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Описание).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
