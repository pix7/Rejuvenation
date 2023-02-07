    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortStory : MonoBehaviour
{
    SessionManager sessionManager;
    SaveLoader saveLoader;
    ScoreKeeper scoreKeeper;
    [SerializeField]
    GameObject gameContainer;
    [SerializeField]
    GameObject endContainer;
    [SerializeField]
    GameObject part1Container;
    [SerializeField]
    GameObject part2Container;
    [SerializeField]
    Text timerText;
    [SerializeField]
    Text storyText;
    [SerializeField]
    Text questionText;
    [SerializeField]
    Text answerText;
    [SerializeField]
    Text endText;
    float timer;
    List<int> scores;

    string[] names = new string[12] {"李波兰","刘刘海","夏饺子","朱小猪","李有冰","刘海海","夏楼梯","朱朱夏","李科生","刘学生","夏大雪","朱嘉李"};
    [SerializeField]
    string[] jobs;
    [SerializeField]
    string[] schools;
    [SerializeField]
    string[] hairColors;
    [SerializeField]
    string[] foods;
    [SerializeField]
    float[] heights;
    [SerializeField]
    string[] petTypes;
    [SerializeField]
    SpriteRenderer backGround;

    Color originalColor;

    string personName;
    string job;
    string school;
    string hairColor;
    string food;
    float height;
    int amountOfFriends;
    string bestFriendName;
    List<string> friendName;
    string petType;
    string petName;
    int petAge;
    string correctAnswer = "";
    [SerializeField]
    int timeAllowedToRead;

    int currentQuestion = 0;
    int maxQuestions = 6;

    List<int> questionIndices;
    int question1Index;
    int question2Index;
    int question3Index;
    int question4Index;
    int question5Index;

    [SerializeField]
    Color red;
    [SerializeField]
    Color green;
    bool hasNotTriggered = true;

    [SerializeField]
    PotentialQuestions[] potentialQuestions;

    AntonymsSfxManager antonymsSfxManager;


    // Start is called before the first frame update
    void Start()
    {
        scores = new List<int>();
        questionIndices = new List<int>();
        friendName = new List<string>();
        sessionManager = FindObjectOfType<SessionManager>();
        saveLoader = FindObjectOfType<SaveLoader>();
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();
        antonymsSfxManager = FindObjectOfType<AntonymsSfxManager>();
        endContainer.SetActive(false);
        gameContainer.SetActive(true);
        originalColor = backGround.material.color;
        SetupGame();
        // timeAllowedToRead -= scoreKeeper.memoryLevel;
        if(timeAllowedToRead < 10)
        {
            timeAllowedToRead = 10;
        }
        timer = timeAllowedToRead;
          
    }

    void SetupGame()
    {
        part2Container.SetActive(false);
        part1Container.SetActive(true);
        question1Index = Random.Range(0, 7);
        question2Index = Random.Range(0, 7);
        question3Index = Random.Range(0, 7);
        question4Index = Random.Range(0, 7);
        question5Index = Random.Range(0, 7);
        while(question2Index == question1Index)
        {
            question2Index = Random.Range(0, 7);
        }
        while(question3Index == question2Index || question3Index == question1Index)
        {
            question3Index = Random.Range(0, 7);
        }
        while (question4Index == question2Index || question4Index == question1Index || question4Index == question3Index)
        {
            question4Index = Random.Range(0, 7);
        }
        while (question5Index == question2Index || question5Index == question1Index || question5Index == question3Index || question5Index == question4Index)
        {
            question5Index = Random.Range(0, 7);
        }
        questionIndices.Add(question1Index);
        questionIndices.Add(question2Index);
        questionIndices.Add(question3Index);
        questionIndices.Add(question4Index);
        questionIndices.Add(question5Index);
        personName = names[Random.Range(0, names.Length - 1)];
        job = jobs[Random.Range(0, jobs.Length - 1)];
        school = schools[Random.Range(0, schools.Length - 1)];
        hairColor = hairColors[Random.Range(0, hairColors.Length - 1)];
        food = foods[Random.Range(0, foods.Length - 1)];
        height = heights[Random.Range(0, heights.Length - 1)];
        amountOfFriends = 1;

        bestFriendName = names[Random.Range(0, names.Length - 1)];
        while(bestFriendName  == personName)
            bestFriendName = names[Random.Range(0, names.Length - 1)];
            
        string bf =names[Random.Range(0, names.Length - 1)];
        for(int i = 0; i < amountOfFriends; i++)
        {
            while(bf == personName || bf == bestFriendName)
                bf =names[Random.Range(0, names.Length - 1)];
                friendName.Add(bf);
        }
        amountOfFriends++;
        petType = petTypes[Random.Range(0, petTypes.Length - 1)];
        petName = names[Random.Range(0, names.Length - 1)];
        petAge = Random.Range(1, 13);
        storyText.text = personName + "是一个毕业于" + school +"的" + job + "。她最喜欢的颜色是" + hairColor + "色，最爱吃" + food + "。";
        storyText.text += "她的朋友是" + bestFriendName + "和"+friendName[0] + "，";

        storyText.text += "她的宠物是一只可爱的" + petType +  "。";
    }

    void SetupQuestion()
    {
        backGround.material.color = originalColor;
        currentQuestion++;        
        if(currentQuestion >= maxQuestions)
        {
            EndGame();
        }

        part2Container.SetActive(true);
        part1Container.SetActive(false);
        int questionIndex;
        switch(currentQuestion)
        {
            case 1: questionIndex = question1Index;break;
            case 2: questionIndex = question2Index; break;
            case 3: questionIndex = question3Index; break;
            case 4: questionIndex = question4Index; break;
            default: questionIndex = question5Index; break;
        }
        questionText.text = potentialQuestions[questionIndex].question;
        switch(questionIndex)
        {
            case 0: correctAnswer = personName.ToUpper(); break;
            case 1: correctAnswer = job.ToUpper(); break;
            case 2: correctAnswer = school.ToUpper(); break;
            case 3: correctAnswer = hairColor.ToUpper(); break;
            case 4: correctAnswer = food.ToUpper(); break;
            case 5: correctAnswer = bestFriendName.ToUpper(); break;
            case 6: correctAnswer = friendName[1].ToUpper(); break;
            case 7: correctAnswer = petType.ToUpper(); break;
        }

    }

    void EndGame()
    {
        endContainer.SetActive(true);
        gameContainer.SetActive(false);
        endText.text = "";
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] == 0)
            {
                endText.text += "第" + (i + 1).ToString() + "轮 | 错误|" + "\n";
            }
            else
            {
                endText.text += "第" + (i + 1).ToString() + "轮 | 正确 | " + scores[i] + " 分" + "\n";
            }
        }
        // endText.text += "\n" + " Well Done, Keep Improving!";
    }

    public void Guess()
    {
        if(answerText.text.ToUpper() == correctAnswer)
        {
                // scoreKeeper.memoryPoints += 100;
                scores.Add(100);
                Camera.main.GetComponent<Animator>().SetTrigger("Shake");
            //     antonymsSfxManager.PlayAudio(true);
            // if (scoreKeeper.memoryPoints > scoreKeeper.pointsRequiredForLevel[scoreKeeper.memoryLevel + 1])
            //     {
            //         scoreKeeper.memoryLevel++;
            //     }
            // saveLoader.SaveGameData(); 
            CorrectAnswer();
        }
        else { scores.Add(0); WrongAnswer(); antonymsSfxManager.PlayAudio(false); }
        answerText.text = "";
    }

    void CorrectAnswer()
    {
        part2Container.SetActive(false);
        backGround.material.color = green;
        Invoke("SetupQuestion", 1f);
    }

    void WrongAnswer()
    {
        part2Container.SetActive(false);
        backGround.material.color = red;
        Invoke("SetupQuestion", 1f);
    }

    public void EnterLetter(string letter)
    {
        answerText.text += letter.ToUpper();
    }

    public void BackLetter(string letter)
    {
        if(answerText.text.Length>0)
            answerText.text = "";
    }

    public void ContinueSession()
    {
        sessionManager.ContinueSession();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0.0");
        
        if(timer<0 && hasNotTriggered)
        {
            SetupQuestion();
            hasNotTriggered = false;
            
            
        }
        Debug.Log(currentQuestion);
    }
    [System.Serializable]
    struct PotentialQuestions
    {
        public int questionIndex;
        public string question;
    }
}
