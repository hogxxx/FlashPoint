using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OrderObject : MonoBehaviour
{
    private List<List<string>> order = new List<List<string>>();
    private static List<List<string>> Bio_7 = new List<List<string>>()
    {
        new List<string>
        {
            "Клітина це структурна і функціональна одиниця життя",
            "Мембрана це оболонка що відокремлює клітину від зовнішнього середовища",
            "Ядро це органела яка керує всіма процесами у клітині"
        },

        new List<string>
        {
            "Цитоплазма це рідка частина клітини з органелами",
            "Мітохондрії це органели що відповідають за енергетику клітини",
            "Хлоропласти це органели рослин для фотосинтезу"
        },

        new List<string>
        {
            "Рибосоми це органели що відповідають за синтез білків",
            "Тканина це група клітин з однаковою функцією",
            "ДНК це носій спадкової інформації у всіх клітинах"
        }
    };

    private static List<List<string>> Bio_8 = new List<List<string>>()
    {
        new List<string>
        {
            "Орган це частина організму що виконує певну функцію",
            "Система органів це група органів що працюють разом",
            "Фотосинтез це процес утворення органічних речовин"
        },

        new List<string>
        {
            "Дихальна система забезпечує газообмін організму з навколишнім середовищем",
            "Кровоносна система це транспортна система організму",
            "М’язова система забезпечує рух організму і підтримку форми"
        },

        new List<string>
        {
            "Імунна система це система що захищає організм від патогенів",
            "Ендокринна система це система регулює роботу організму через гормони",
            "Нервова система це система регуляції організму"
        }
    };
    private static List<List<string>> Bio_9 = new List<List<string>>()
    {
        new List<string>
        {
            "Ген це одиниця спадкової інформації в ДНК",
            "Хромосома це структура з ДНК і білків у клітині",
            "Мітоз це поділ клітини на дві дочірні з однаковим набором хромосом"
        },

        new List<string>
        {
            "Мейоз це процес поділу клітини для утворення гамет",
            "Кросинговер це обмін ділянками ДНК між хромосомами",
            "Фенотип це сукупність зовнішніх ознак організму"
        },

        new List<string>
        {
            "Генотип це генетична інформація організму",
            "Мутація це зміна генетичної інформації організму",
            "Еволюція це процес поступових змін у живих організмах"
        }
    };

    private static List<List<string>> Bio_10 = new List<List<string>>()
    {
        new List<string>
        {
            "Популяція це група організмів одного виду в середовищі",
            "Екосистема це система взаємодії живих організмів і середовища",
            "Біосфера це глобальна екосистема Землі що включає всі живі організми"
        },

        new List<string>
        {
            "Біоценоз це сукупність популяцій в одному середовищі",
            "Ланцюг живлення це послідовність передачі енергії через організми",
            "Продуценти це організми що створюють органічні речовини"
        },

        new List<string>
        {
            "Консументи це організми що живляться іншими організмами",
            "Редуценти це організми що розкладають мертву матерію",
            "Екологія це наука про взаємодію організмів і середовища"
        }
    };

    private static List<List<string>> Bio_11 = new List<List<string>>()
    {
        new List<string>
        {
            "Гомеостаз це здатність організму підтримувати стабільний стан",
            "Імунітет це здатність організму захищатися від інфекцій",
            "Ендемічний вид це вид що мешкає лише в одній області"
        },

        new List<string>
        {
            "Мікроорганізми це організми видимі тільки під мікроскопом",
            "Селекція це процес створення нових сортів рослин або порід тварин",
            "Біотехнологія це використання живих організмів для отримання продуктів"
        },

        new List<string>
        {
            "Генна інженерія це внесення змін до генів організмів",
            "Клітинна інженерія це створення штучних тканин і клітин",
            "Експресія генів це процес реалізації генетичної інформації"
        }
    };
    private static List<List<string>> Chem_7 = new List<List<string>>()
    {
        new List<string>
        {
            "Атом це найменша частинка хімічного елемента",
            "Молекула це частинка що складається з атомів",
            "Хімічний елемент це сукупність атомів з однаковим зарядом"
        },

        new List<string>
        {
            "Реакція це процес перетворення одних речовин в інші",
            "Оксиди це сполуки кисню з іншими елементами",
            "Суміш це дві або більше речовин без хімічного зв'язку"
        },

        new List<string>
        {
            "Хімічний зв'язок це взаємодія атомів у молекулах",
            "Іон це заряджена частинка що утворюється з атома",
            "Каталізатор це речовина що прискорює хімічну реакцію"
        }
    };

    private static List<List<string>> Chem_8 = new List<List<string>>()
    {
        new List<string>
        {
            "Кислоти це речовини що віддають іони водню",
            "Основа це речовина що приймає іони водню",
            "Сіль це продукт реакції кислоти і основи"
        },

        new List<string>
        {
            "Реакція нейтралізації це взаємодія кислоти з основою",
            "Розчин це однорідна суміш двох або більше речовин",
            "Молярність це концентрація речовини в розчині"
        },

        new List<string>
        {
            "Окиснення це процес втрати електронів атомом або йоном",
            "Відновлення це процес приєднання електронів атомом",
            "Хімічна рівновага це стан реакції коли швидкості рівні"
        }
    };

    private static List<List<string>> Chem_9 = new List<List<string>>()
    {
        new List<string>
        {
            "Органічна хімія це наука про сполуки вуглецю",
            "Алкани це насичені вуглеводні з одинарними зв'язками",
            "Алкени це ненасичені вуглеводні з подвійними зв'язками"
        },

        new List<string>
        {
            "Алкіни це ненасичені вуглеводні з потрійними зв'язками",
            "Ароматичні сполуки це органічні речовини з бензольним кільцем",
            "Ізомерія це існування сполук з однаковою формулою але різною будовою"
        },

        new List<string>
        {
            "Полімери це речовини з великими молекулами що повторюються",
            "Білки це органічні речовини з амінокислот",
            "Вуглеводи це органічні сполуки з вуглецю водню і кисню"
        }
    };

    private static List<List<string>> Chem_10 = new List<List<string>>()
    {
        new List<string>
        {
            "Електроліти це речовини що проводять електричний струм у розчині",
            "Неелектроліти це речовини що не проводять струм",
            "Електрохімічні реакції це процеси за участю електронів"
        },

        new List<string>
        {
            "Реакція розкладу це процес розпаду речовини на простіші",
            "Реакція сполучення це утворення складної речовини з простіших",
            "Оксидування це хімічний процес взаємодії з киснем"
        },

        new List<string>
        {
            "Ентальпія це тепловий ефект хімічної реакції",
            "Каталіз це прискорення хімічної реакції за допомогою каталізатора",
            "Реакція заміщення це процес заміни атомів в молекулі"
        }
    };

    private static List<List<string>> Chem_11 = new List<List<string>>()
    {
        new List<string>
        {
            "Біохімія це наука про хімічні процеси в живих організмах",
            "ДНК це нуклеїнова кислота що несе спадкову інформацію",
            "РНК це молекула що бере участь у синтезі білків"
        },

        new List<string>
        {
            "Ферменти це білки що каталізують біохімічні реакції",
            "Ліпіди це органічні речовини з жировими компонентами",
            "Амінокислоти це основа для побудови білків"
        },

        new List<string>
        {
            "Фотосинтез це процес утворення органічних речовин із СО2",
            "Карбонатна кислота це слабка кислота що містить СО2",
            "Редокс-реакції це окисно-відновні хімічні процеси"
        }
    };
    private static List<List<string>> Phys_7 = new List<List<string>>()
    {
        new List<string>
        {
            "Механічний рух це зміна положення тіла у просторі",
            "Швидкість це фізична величина що визначає рух тіла",
            "Сила це взаємодія, що змінює рух тіла"
        },

        new List<string>
        {
            "Прискорення це зміна швидкості руху з часом",
            "Маса це фізична величина що визначає кількість речовини",
            "Гравітація це сила притягання між тілами у Всесвіті"
        },

        new List<string>
        {
            "Тиск це сила яка діє на одиницю площі",
            "Енергія це здатність тіла виконувати роботу",
            "Рівнодійна сила це заміна кількох сил однією силою"
        }
    };
    private static List<List<string>> Phys_8 = new List<List<string>>()
    {
        new List<string>
        {
            "Електричний струм це рух заряджених частинок у провіднику",
            "Напруга це фізична величина що визначає роботу струму",
            "Сила струму це кількість заряду що проходить за час"
        },

        new List<string>
        {
            "Опір це фізична величина що перешкоджає струму у провіднику",
            "Магнітне поле це поле що створюється електричним струмом",
            "Закон Ома це співвідношення між напругою і струмом"
        },

        new List<string>
        {
            "Електромагнітна індукція це явище виникнення струму в провіднику",
            "Резонанс це явище різкого збільшення амплітуди коливань",
            "Тепловий рух це хаотичний рух молекул у речовині"
        }
    };

    private static List<List<string>> Phys_9 = new List<List<string>>()
    {
        new List<string>
        {
            "Світло це електромагнітна хвиля яку сприймає око",
            "Поглинання світла це процес зменшення його інтенсивності",
            "Заломлення світла це зміна напрямку його поширення"
        },

        new List<string>
        {
            "Дисперсія це розкладання світла на спектральні кольори",
            "Звукові хвилі це механічні хвилі які розповсюджуються в середовищі",
            "Розсіювання світла це процес відбиття від частинок речовини"
        },

        new List<string>
        {
            "Радіоактивність це процес спонтанного розпаду ядер атомів",
            "Альфа-випромінювання це потік ядер гелію які випромінює ядро",
            "Ядерний синтез це процес злиття легких ядер у важчі"
        }
    };

    private static List<List<string>> Phys_10 = new List<List<string>>()
    {
        new List<string>
        {
            "Імпульс це величина що характеризує рух тіла",
            "Закон збереження енергії це фундаментальний принцип фізики",
            "Закон Ньютона це три основні закони механіки"
        },

        new List<string>
        {
            "Гармонічні коливання це рух що повторюється через рівні проміжки часу",
            "Закон Кулона це закон взаємодії заряджених частинок",
            "Термодинаміка це наука про тепло і роботу"
        },

        new List<string>
        {
            "Тепловий двигун це пристрій що перетворює тепло в роботу",
            "Закон Фарадея це явище електромагнітної індукції в провіднику",
            "Електромагнітна хвиля це поширення змінного електромагнітного поля"
        }
    };

    private static List<List<string>> Phys_11 = new List<List<string>>()
    {
        new List<string>
        {
            "Квантова механіка це фізика мікросвіту і поведінки частинок",
            "Релятивістська механіка це розділ фізики що враховує швидкості світла",
            "Фотон це частинка світла яка переносить енергію"
        },

        new List<string>
        {
            "Ефект Комптона це розсіювання фотона на зарядженій частинці",
            "Ядерна енергія це енергія що вивільняється з ядра атома",
            "Ентропія це міра невпорядкованості системи у термодинаміці"
        },

        new List<string>
        {
            "Лазер це пристрій для генерації когерентного світла",
            "Плазма це стан речовини з вільними електронами і йонами",
            "Закон Планка це опис залежності енергії від частоти випромінювання"
        }
    };
    private static List<List<string>> IT_7 = new List<List<string>>()
    {
        new List<string>
        {
            "Інформація це відомості незалежно від форми їх подання",
            "Дані це факти які можуть бути опрацьовані",
            "Програма це набір інструкцій які виконує комп'ютер"
        },

        new List<string>
        {
            "Алгоритм це послідовність дій для вирішення задачі",
            "Комп'ютер це електронний пристрій для обробки даних",
            "Файл це набір даних збережених на носії інформації"
        },

        new List<string>
        {
            "Операційна система це програма яка керує роботою комп'ютера",
            "Мережа це група комп'ютерів які можуть обмінюватись даними",
            "База даних це організоване зберігання інформації для швидкого пошуку"
        }
    };
    private static List<List<string>> IT_8 = new List<List<string>>()
    {
        new List<string>
        {
            "Біт це найменша одиниця інформації в комп'ютері",
            "Байт це одиниця інформації яка складається з 8 бітів",
            "Програмування це процес створення програм для комп'ютера"
        },

        new List<string>
        {
            "Цикл це команда для повторення набору дій",
            "Масив це набір даних одного типу з одним ім'ям",
            "Функція це набір інструкцій що виконує певну задачу"
        },

        new List<string>
        {
            "Хмарні технології це сервіси для обробки даних в інтернеті",
            "Інтернет це глобальна мережа з'єднаних комп'ютерів",
            "Кібербезпека це заходи для захисту інформації в мережі"
        }
    };
    private static List<List<string>> IT_9 = new List<List<string>>()
    {
        new List<string>
        {
            "Кодування інформації це перетворення даних для опрацювання",
            "Двійкова система це числова система з основою два",
            "Мова програмування це спосіб написання алгоритмів для комп'ютера"
        },

        new List<string>
        {
            "Перемінна це область пам'яті для збереження даних програмою",
            "Тип даних це характеристика змінної для збереження значень",
            "Компіляція це процес переводу вихідного коду у машинний"
        },

        new List<string>
        {
            "Комп'ютерна графіка це створення зображень за допомогою комп'ютера",
            "Система баз даних це програма для роботи даними",
            "Алгоритм сортування це спосіб упорядкування елементів списку"
        }
    };
    private static List<List<string>> IT_10 = new List<List<string>>()
    {
        new List<string>
        {
            "Об'єктно-орієнтоване програмування це робота з об'єктами і класами",
            "Клас це шаблон для створення об'єктів з однаковими властивостями",
            "Об'єкт це екземпляр класу з конкретними властивостями та методами"
        },

        new List<string>
        {
            "Інкапсуляція це приховування деталей об'єкта від зовнішнього доступу",
            "Наслідування це передача властивостей класу до його нащадків",
            "Поліморфізм це використання одного інтерфейсу для різних класів"
        },

        new List<string>
        {
            "Скрипт це програмний код для виконання автоматичних завдань",
            "Мережевий протокол це набір правил обміну даними у мережі",
            "DNS це система відповідності доменів і IP-адрес"
        }
    };
    private static List<List<string>> IT_11 = new List<List<string>>()
    {
        new List<string>
        {
            "Штучний інтелект це здатність машин виконувати складні задачі",
            "Машинне навчання це підгалузь інтелекту для роботи з даними",
            "Блокчейн це технологія для децентралізованого зберігання даних"
        },

        new List<string>
        {
            "Інтернет речей це мережа пристроїв з обміном даними через інтернет",
            "Віртуальна реальність це створення тривимірних віртуальних середовищ",
            "Хешування це перетворення даних у фіксовану послідовність символів"
        },

        new List<string>
        {
            "Квантовий комп'ютер це пристрій для обчислень на квантових принципах",
            "Великі дані це великі обсяги інформації для аналізу і обробки",
            "Кіберетика це моральні принципи роботи з інформаційними технологіями"
        }
    };
    private static List<List<string>> Math_7 = new List<List<string>>()
    {
        new List<string>
        {
            "Дріб це число представлене у вигляді частини цілого",
            "Раціональне число це число яке можна записати дробом",
            "Кут це геометрична фігура утворена двома променями"
        },

        new List<string>
        {
            "Множення це математична операція додавання одного числа кілька разів",
            "Пропорція це рівність двох відношень між числами",
            "Графік це зображення залежності між двома змінними"
        },

        new List<string>
        {
            "Рівняння це математичне твердження про рівність двох виразів",
            "Площина це безмежна плоска поверхня у геометрії",
            "Модуль числа це відстань числа від нуля на осі"
        }
    };

    private static List<List<string>> Math_8 = new List<List<string>>()
    {
        new List<string>
        {
            "Квадратний корінь це число квадрат якого дорівнює даному",
            "Ірраціональне число це число яке не можна записати дробом",
            "Геометрична прогресія це послідовність чисел зі спільним множником"
        },

        new List<string>
        {
            "Функція це залежність між змінними описана рівнянням",
            "Графік функції це зображення залежності змінних на координатній площині",
            "Система рівнянь це набір рівнянь для знаходження спільного розв'язку"
        },

        new List<string>
        {
            "Координатна площина це система осей для визначення положення точок",
            "Квадратне рівняння це рівняння другого степеня у математиці",
            "Перетин множин це спільні елементи кількох множин"
        }
    };

    private static List<List<string>> Math_9 = new List<List<string>>()
    {
        new List<string>
        {
            "Похідна це швидкість зміни функції у заданій точці",
            "Логарифм це число яке показує ступінь основи для отримання числа",
            "Гіпотенуза це найдовша сторона прямокутного трикутника"
        },

        new List<string>
        {
            "Многочлен це алгебраїчний вираз що складається з кількох доданків",
            "Дискримінант це параметр який визначає кількість коренів рівняння",
            "Ось симетрії це пряма яка ділить фігуру на дві рівні частини"
        },

        new List<string>
        {
            "Скалярний добуток це результат множення двох векторів на площині",
            "Теорема це математичне твердження яке можна довести логічно",
            "Комбінаторика це розділ математики про обчислення кількості способів"
        }
    };

    private static List<List<string>> Math_10 = new List<List<string>>()
    {
        new List<string>
        {
            "Інтеграл це операція обчислення площі під графіком функції",
            "Експонента це функція вигляду a^x де a більше нуля",
            "Парабола це графік квадратного рівняння другого степеня"
        },

        new List<string>
        {
            "Тригонометрія це розділ математики про кути і трикутники",
            "Синус кута це відношення протилежного катета до гіпотенузи",
            "Косинус кута це відношення прилеглого катета до гіпотенузи"
        },

        new List<string>
        {
            "Асимптота це пряма до якої графік функції нескінченно наближається",
            "Геометричне місце точок це множина точок що задовольняють умову",
            "Центр ваги це точка рівноваги геометричної фігури"
        }
    };

    private static List<List<string>> Math_11 = new List<List<string>>()
    {
        new List<string>
        {
            "Диференціальне рівняння це рівняння із похідними невідомої функції",
            "Лінійна алгебра це розділ математики про матриці і вектори",
            "Матричний добуток це результат множення двох матриць"
        },

        new List<string>
        {
            "Комбінаторна ймовірність це розрахунок ймовірності на множинах подій",
            "Градієнт це вектор що показує напрямок найбільшого зростання функції",
            "Диференціал це вираз який приблизно дорівнює зміні функції"
        },

        new List<string>
        {
            "Числовий ряд це послідовність чисел, об'єднаних у суму",
            "Конус це геометричне тіло утворене обертанням трикутника",
            "Еліпс це множина точок сума відстаней яких до фокусів стала"
        }
    };
    private static List<string> distractingWords_Bio = new List<string>
    {
        "клітина",
        "орган",
        "тканина",
        "ген",
        "мембрана",
        "хромосома",
        "мутант",
        "ДНК",
        "РНК",
        "організм",
        "екосистема",
        "вода",
        "кров",
        "нерв",
        "м’яз",
        "іон",
        "вітамін",
        "гомеостаз",
        "реплікація",
        "мітохондрія",
        "ендоплазма",
        "метаболізм",
        "вид",
        "популяція",
        "селекція",
        "фотосинтез",
        "біосфера"
    };

    private static List<string> distractingWords_Chem = new List<string>
    {
        "атом",
        "молекула",
        "реакція",
        "кислота",
        "лужність",
        "розчин",
        "каталізатор",
        "енергія",
        "електроліт",
        "валентність",
        "окиснення",
        "відновлення",
        "газ",
        "сіль",
        "кисень",
        "водень",
        "температура",
        "пластик",
        "радіус атома",
        "гідроліз",
        "алотропія",
        "хімічний зв'язок",
        "масова частка",
        "йон",
        "фтор",
        "ізотоп",
        "растворність"
    };
    private static List<string> distractingWords_Phys = new List<string>
    {
        "сила",
        "енергія",
        "імпульс",
        "маса",
        "швидкість",
        "прискорення",
        "вага",
        "тиск",
        "об’єм",
        "температура",
        "тертя",
        "гравітація",
        "кінетика",
        "момент",
        "резонанс",
        "електрон",
        "магніт",
        "фотон",
        "струм",
        "індукція",
        "опір",
        "потенціал",
        "напруга",
        "амплітуда",
        "частота",
        "відстань",
        "хвиля"
    };
    private static List<string> distractingWords_IT = new List<string>
    {
        "інформація",
        "кодування",
        "процес",
        "пам'ять",
        "пристрій",
        "біт",
        "байт",
        "сервер",
        "компіляція",
        "диск",
        "команда",
        "підключення",
        "редактор",
        "дані",
        "кеш",
        "адаптер",
        "моніторинг",
        "протокол",
        "шифрування",
        "мережа",
        "архівування",
        "логіка",
        "алгоритм",
        "перемикач",
        "вебсайт",
        "пакет",
        "інтерфейс"
    };
    private static List<string> distractingWords_Math = new List<string>
    {
        "число",
        "дроби",
        "вектор",
        "координати",
        "периметр",
        "площа",
        "об’єм",
        "радіус",
        "кут",
        "рівняння",
        "функція",
        "графік",
        "диференціал",
        "логарифм",
        "матриця",
        "похідна",
        "інтеграл",
        "гіпотенуза",
        "парабола",
        "паралель",
        "асимптота",
        "симетрія",
        "пропорція",
        "дискримінант",
        "множення",
        "геометрія",
        "чисельник"
    };

    public Button ready;
    public List<Toggle> toggles;
    public TextMeshProUGUI Choose;
    private List<string> subjects = new List<string>();
    private int classint;
    void Start()
    {
        classint = PlayerPrefs.GetInt("Class");
        foreach (Toggle order in toggles)
        {
            order.onValueChanged.AddListener(delegate { Changelist(); });
        }
        ready.onClick.AddListener(Save);
    }
    private void Changelist()
    {
        subjects.Clear();
        foreach (Toggle order in toggles)
        {
            if (order.isOn)
            {
                TextMeshProUGUI ObjectName = order.GetComponentInChildren<TextMeshProUGUI>(true);
                if (ObjectName != null)
                {
                    subjects.Add(ObjectName.text);
                }
            }
        }
    }
    private void Save()
    {
        if (subjects.Count > 0)
        {
            foreach (string lesson in subjects)
            {
                Check(lesson, classint);
            }
            FileManager.SaveOrder(order);
            PlayerPrefs.SetInt("Object", 0);
            PlayerPrefs.SetInt("Chooser", order.Count);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main");
        }
        else
        {
            StartCoroutine(Error());
        }
    }
    private IEnumerator Error()
    {
        Choose.text = "Обери предмет!";
        Choose.color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
        yield return new WaitForSeconds(1.5f);
        Choose.text = "Обери предмет";
        Choose.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    }
    private void Check(string name, int classint)
    {
        if (name == "Bio")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Bio_7);
                    break;
                case 8:
                    order = Connecter(order, Bio_8);
                    break;
                case 9:
                    order = Connecter(order, Bio_9);
                    break;
                case 10:
                    order = Connecter(order, Bio_10);
                    break;
                case 11:
                    order = Connecter(order, Bio_11);
                    break;
            }
        }
        else if (name == "Chem")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Chem_7);
                    break;
                case 8:
                    order = Connecter(order, Chem_8);
                    break;
                case 9:
                    order = Connecter(order, Chem_9);
                    break;
                case 10:
                    order = Connecter(order, Chem_10);
                    break;
                case 11:
                    order = Connecter(order, Chem_11);
                    break;
            }
        }
        else if (name == "Phys")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Phys_7);
                    break;
                case 8:
                    order = Connecter(order, Phys_8);
                    break;
                case 9:
                    order = Connecter(order, Phys_9);
                    break;
                case 10:
                    order = Connecter(order, Phys_10);
                    break;
                case 11:
                    order = Connecter(order, Phys_11);
                    break;
            }
        }
        else if (name == "IT")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, IT_7);
                    break;
                case 8:
                    order = Connecter(order, IT_8);
                    break;
                case 9:
                    order = Connecter(order, IT_9);
                    break;
                case 10:
                    order = Connecter(order, IT_10);
                    break;
                case 11:
                    order = Connecter(order, IT_11);
                    break;
            }
        }
        else if (name == "Math")
        {
            switch (classint)
            {
                case 7:
                    order = Connecter(order, Math_7);
                    break;
                case 8:
                    order = Connecter(order, Math_8);
                    break;
                case 9:
                    order = Connecter(order, Math_9);
                    break;
                case 10:
                    order = Connecter(order, Math_10);
                    break;
                case 11:
                    order = Connecter(order, Math_11);
                    break;
            }
        }
    }
    private List<List<string>> Connecter(List<List<string>> order1, List<List<string>> adder)
    {
        int minnum = Mathf.Min(order1.Count, adder.Count);
        for (int i = 0; i < minnum; i++)
        {
            order1[i].AddRange(adder[i]);
        }
        for (int j = minnum; j < adder.Count; j++)
        {
            order1.Add(new List<string>(adder[j]));
        }
        return order1;
    }
    public static void CheckTerm(string term)
    {
        List<List<List<string>>> allLists_IT = new List<List<List<string>>> { IT_7, IT_8, IT_9, IT_10, IT_11 };
        if (SetList(term, allLists_IT, distractingWords_IT)) return;

        List<List<List<string>>> allLists_Math = new List<List<List<string>>> { Math_7, Math_8, Math_9, Math_10, Math_11 };
        if (SetList(term, allLists_Math, distractingWords_Math)) return;

        List<List<List<string>>> allLists_Phys = new List<List<List<string>>> { Phys_7, Phys_8, Phys_9, Phys_10, Phys_11 };
        if (SetList(term, allLists_Phys, distractingWords_Phys)) return;

        List<List<List<string>>> allLists_Chem = new List<List<List<string>>> { Chem_7, Chem_8, Chem_9, Chem_10, Chem_11 };
        if (SetList(term, allLists_Chem, distractingWords_Chem)) return;

        List<List<List<string>>> allLists_Bio = new List<List<List<string>>> { Bio_7, Bio_8, Bio_9, Bio_10, Bio_11 };
        if (SetList(term, allLists_Bio, distractingWords_Bio)) return;
    }
    public static bool SetList(string term, List<List<List<string>>> allLists,List<string> distractingWords)
    {
        foreach (List<List<string>> lister1 in allLists)
        {
            foreach (List<string> lister in lister1)
            {
                foreach (string termer in lister)
                {
                    if (termer.Split(" ")[0] == term)
                    {
                        DistructWords.distructwords = distractingWords;
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
public static class DistructWords
{
    public static List<string> distructwords { get; set; } = new List<string>();
}
public static class FileManager
{
    private static string filepath;
    private static void InitializeFilePath()
    {
        if (string.IsNullOrEmpty(filepath))
        {
            filepath = Application.persistentDataPath + "/order.json";
        }
    }
    public static void SaveOrder(List<List<string>> orderlist)
    {
        InitializeFilePath();
        OrderLister orderlister = new OrderLister();
        foreach (var item in orderlist)
        {
            orderlister.orderlister1.Add(new SerializableList { Liber = item });
        }
        string json = JsonUtility.ToJson(orderlister, true);
        File.WriteAllText(filepath, json);
    }
    public static List<List<string>> LoadTerms()
    {
        InitializeFilePath();
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            OrderLister filegot = JsonUtility.FromJson<OrderLister>(json);
            List<List<string>> result = new List<List<string>>();
            if (filegot.orderlister1 != null && filegot != null)
            {
                foreach (var serialize in filegot.orderlister1)
                {
                    result.Add(serialize.Liber);
                }
            }
            return result;
        }
        else
        {
            return new List<List<string>>();
        }
    }
}
[System.Serializable]
public class SerializableList
{
    public List<string> Liber = new List<string>();
}
public class OrderLister
{
    public List<SerializableList> orderlister1 = new List<SerializableList>();
}