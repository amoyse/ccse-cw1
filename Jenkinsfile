pipeline {
 
    agent any

 
    stages {
        stage('Checkout') {
            steps {
                git credentialsId: 'github-pat', url: 'https://github.com/amoyse/pacific-tours.git'}
        }

        stage('Build') {
            steps {
                script {
                    sh 'dotnet restore'
                    sh 'dotnet build --configuration Release'
                }
            }
        }
 
        stage('Docker Build') {
            steps {
                script {
                    sh 'docker build -t amoyse42/pacific-tours:$BUILD_NUMBER .'
                }
            }
        }
 
        stage('Deploy') {
            steps {
                script {
                    withCredentials([usernamePassword(credentialsId: 'dockerhub', passwordVariable: 'dhpass', usernameVariable: 'dhuser')]) {
                        sh 'docker login -u ${dhuser} -p ${dhpass}'
                        sh 'docker push amoyse42/pacific-tours'
                    }
                }
            }
        }
 
 
    }
     post {
        always {
            cleanWs()
        }
    }
}

