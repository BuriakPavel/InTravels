import { IPost } from '../classes/post';
import { Comment } from '../classes/comment';

export let posts: IPost[] = [
        {
            id: 1,
            UserName: "Macdonald Bates",
            LikesCount: 25,
            PublishDate: "Tuesday, September 6, 2016 10:21 PM",
            Image: "content/images/female-2.png",
            Title: "elit ipsum voluptate labore incididunt",
            Text: "Labore sint enim do nulla cupidatat sit do laboris velit aute duis et amet. Ad nulla id amet ad nostrud ex. Et nostrud reprehenderit dolore et quis labore exercitation. Proident fugiat fugiat ut incididunt laboris eu et veniam elit occaecat excepteur dolore minim.\n\nNostrud pariatur officia dolore aliquip minim culpa anim ex non esse. Eiusmod est ullamco sunt consequat excepteur labore laborum nisi ullamco nisi. Elit incididunt est minim officia sit excepteur ea incididunt pariatur veniam. Tempor amet pariatur voluptate veniam cillum officia sint elit labore cupidatat minim minim nostrud irure.",
            Tags: ["amet", "cillum"],
            Comments:
            [
                {
                    Text: "Duis eiusmod sint magna mollit occaecat Lorem ullamco elit non adipisicing culpa dolore eiusmod. Et non est laboris ut exercitation. Anim duis esse labore exercitation nisi occaecat veniam tempor adipisicing velit ex. Ad aute commodo velit excepteur nulla tempor incididunt ea velit fugiat.",
                    Image: "content/images/female-2.png",
                    PublishDate: "Saturday, November 22, 2014 1:52 AM",
                    PostId: 4,
                    UserName: "Gordon Vance",
                    id: 0
                },
                {
                    Text: "Ea mollit pariatur est laboris qui ex laborum sit officia adipisicing nulla. Dolor in laborum esse exercitation ex cupidatat. Ut consequat qui eiusmod anim nulla id do eiusmod aliqua sit ad anim.",
                    Image: "content/images/female-2.png",
                    PublishDate: "Tuesday, February 11, 2014 8:06 PM",
                    PostId: 8,
                    UserName: "Alexis Lamb",
                    id: 1
                }
            ]
        },
        {
            id: 2,
            LikesCount: 10,
            Tags: ["dolore", "aute", "Lorem", "aliquip", "do"],
            Text: "Enim nisi deserunt labore deserunt sit adipisicing tempor tempor consectetur amet. Est qui Lorem dolore consequat adipisicing esse deserunt irure veniam. Ex culpa id tempor esse non reprehenderit proident ut ipsum nisi. Pariatur minim quis deserunt qui elit est pariatur ad ipsum deserunt voluptate minim eiusmod. Amet culpa et consectetur laborum do. Eu id minim veniam irure magna culpa. Quis labore sit ipsum adipisicing cillum anim deserunt voluptate non cillum sint laboris sunt consectetur.\n\nMollit velit tempor minim aliqua dolor. Non exercitation reprehenderit consectetur irure tempor sit veniam qui aliquip dolor. Non officia id et anim proident consequat minim ea irure. Id mollit aliquip dolor nostrud amet tempor magna pariatur elit eu reprehenderit minim. Reprehenderit commodo minim esse ad dolore ipsum anim ex duis velit. Consequat anim eiusmod cupidatat et elit excepteur veniam nisi ipsum laboris occaecat Lorem mollit.",
            Title: "adipisicing pariatur excepteur laboris labore",
            Image: "content/images/female-1.png",
            PublishDate: "Sunday, January 19, 2014 9:00 AM",
            UserName: "Hardin Tillman",
            Comments:
            [
                {
                    Text: "Cupidatat commodo ullamco deserunt voluptate non nulla cillum ex laborum. Duis adipisicing consectetur ea ex. Laboris dolor laboris nulla do fugiat eu irure ullamco. Tempor qui irure in sint est quis aliqua quis mollit id nulla sint ut. Excepteur tempor Lorem magna nostrud esse dolor ipsum qui occaecat ullamco consequat elit fugiat. Adipisicing et Lorem nulla cillum magna culpa ullamco pariatur magna non ea officia. Ullamco minim nulla exercitation elit sit in elit enim exercitation.",
                    Image: "content/images/female-1.png",
                    PublishDate: "Monday, July 7, 2014 6:31 PM",
                    PostId: 18,
                    UserName: "Brandi Rocha",
                    id: 5
                },
                {
                    Text: "Laboris fugiat quis veniam proident sunt officia eiusmod sit sint aliquip labore minim exercitation irure. Lorem elit occaecat dolore cupidatat consectetur laborum. Do exercitation et voluptate occaecat enim eiusmod. Nisi consequat magna officia eu occaecat nisi culpa reprehenderit ullamco dolore mollit eiusmod eiusmod voluptate. Elit officia Lorem ut fugiat incididunt nisi do officia id dolor do.",
                    Image: "content/images/female-2.png",
                    PublishDate: "Saturday, June 13, 2015 11:19 PM",
                    PostId: 18,
                    UserName: "Deirdre Marsh",
                    id: 1
                },
                {
                    Text: "Elit duis nostrud mollit proident do nulla. Cupidatat consequat non aliqua cupidatat do culpa dolor id consequat aute tempor laboris aliqua sit. Do ipsum ullamco officia laborum labore aliqua minim consequat Lorem ut. Nulla minim aliqua nostrud est aute quis. Duis officia est nisi nisi ut quis consectetur culpa non magna veniam elit. Culpa quis dolore anim qui deserunt anim tempor nulla eu aliquip qui dolor labore voluptate.",
                    Image: "content/images/male-2.png",
                    PublishDate: "Saturday, July 16, 2016 6:02 PM",
                    PostId: 9,
                    UserName: "Milagros Burgess",
                    id: 2
                }
            ]
        }
];